using Android.App;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Telephony;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phone = Android.Provider.ContactsContract.CommonDataKinds.Phone;

namespace DroidSpike
{
    [Activity(Label = "DroidSpike", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private ProgressBar pBar;

        private bool pBarOn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button button2 = FindViewById<Button>(Resource.Id.MyButton2);

            EditText phone = FindViewById<EditText>(Resource.Id.editText2);
            phone.AddTextChangedListener(new PhoneNumberFormattingTextWatcher());

            pBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            button.Click += delegate
            {
                try
                {
                    ToggleProgressBar();

                    //OnMultiPass();

                    //var numbers = GetPhoneNumbers();
                    //var user = numbers.Last(s => s != null);
                    //button.Text = user.DisplayName + " " + user.Number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

            button2.Click += delegate
            {
                try
                {
                    IncrementProgressBar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
        }

        private static void DumpIds(Dictionary<string, string> userIds)
        {
            Console.WriteLine("**START**************************************************");
            string allKeys = string.Join(System.Environment.NewLine, userIds.Keys.ToArray());
            Console.WriteLine(allKeys);
            Console.WriteLine("**END****************************************************");
        }

        private IEnumerable<YarlyContact> GetPhoneNumbers()
        {
            List<string> userIds = null;
            var cr = ContentResolver;

            string idColumnName = ContactsContract.PhoneLookup.InterfaceConsts.Id;
            using (var cur = cr.Query(ContactsContract.Contacts.ContentUri, new string[] { idColumnName }, null, null, null))
            {
                int idIndex = cur.GetColumnIndex(idColumnName);

                var reader = new CursorReader<string>(cur, c => c.GetString(idIndex));
                userIds = reader.ToList();
            }

            string selection = GetSelection(userIds);
            userIds.Add("0"); // has phone

            using (var pCur = cr.Query(Phone.ContentUri,
                null,                //new string[] { ContactsContract.PhoneLookup.InterfaceConsts.DisplayName, Phone.Number },
                selection,
                userIds.ToArray(),
                null))
            {
                var x = pCur.GetColumnNames();
                int numberField = pCur.GetColumnIndex(Phone.Number);
                int displayNameField = pCur.GetColumnIndex(ContactsContract.PhoneLookup.InterfaceConsts.DisplayName);

                var reader2 = new CursorReader<YarlyContact>(pCur, c =>
                                                                        {
                                                                            for (int i = 0; i < pCur.GetColumnNames().Count(); i++)
                                                                            {
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        string name = pCur.GetColumnName(i);
                                                                                        string value = pCur.GetString(i);
                                                                                        Console.WriteLine("{0} - {1}", name, value);
                                                                                    }
                                                                                    catch (Exception)
                                                                                    {
                                                                                    }
                                                                                }
                                                                            }

                                                                            Console.WriteLine();
                                                                            Console.WriteLine();
                                                                            Console.WriteLine();
                                                                            Console.WriteLine();

                                                                            string phoneNo = pCur.GetString(numberField);
                                                                            string displayName = pCur.GetString(displayNameField);

                                                                            return new YarlyContact(displayName, phoneNo);
                                                                        });

                foreach (var item in reader2)
                {
                    Console.WriteLine(item);
                    yield return item;
                }
            }
        }

        private IEnumerable<YarlyContact> GetPhoneNumbersSlow()
        {
            List<string> numbers = new List<string>();
            Dictionary<string, string> userIds = new Dictionary<string, string>();
            var cr = ContentResolver;

            using (var cur = cr.Query(ContactsContract.Contacts.ContentUri, null, null, null, null))
            {
                var reader = new CursorReader<CursorContact>(cur, c => new CursorContact(c));

                foreach (var contact in reader.Where(c => c.HasPhone))
                {
                    string selection = Phone.InterfaceConsts.ContactId + " = ?";
                    string[] parameters = new string[] { contact.Id };
                    userIds[contact.Id] = contact.Id;

                    using (var pCur = cr.Query(Phone.ContentUri, new string[] { Phone.Number }, selection, parameters, null))
                    {
                        var x = pCur.GetColumnNames();
                        var reader2 = new CursorReader<YarlyContact>(pCur, c =>
                        {
                            int numberField = c.GetColumnIndex(Phone.Number);
                            string phoneNo = pCur.GetString(numberField);
                            return new YarlyContact(contact.DisplayName, phoneNo);
                        });

                        foreach (var item in reader2)
                        {
                            yield return item;
                        }
                        break;
                    }
                }
            }

            //DumpIds(userIds);
        }

        private string GetSelection(IEnumerable<string> userIds)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < userIds.Count(); i++)
            {
                sb.AppendFormat("{0} = ? OR ", Phone.InterfaceConsts.ContactId);
            }
            sb.Length -= "OR ".Length;
            sb.Append(")");

            sb.AppendFormat("AND {0} != ?", Phone.InterfaceConsts.HasPhoneNumber);

            string where = sb.ToString();
            return where;
        }

        private void IncrementProgressBar()
        {
            if (pBar.Progress > pBar.Max)
            {
                pBar.Progress = 0;
            }
            else
            {
                pBar.IncrementProgressBy(10);
            }
        }

        private void MultiPass()
        {
            try
            {
                string[] userIds = new string[] { "792",
                                                  "757",
                                                  "770",
                                                  "771",
                                                  "843",
                                                  "961",
                                                  "960",
                                                  "988",
                                                  "752",
                                                 };
                string selection = GetSelection(userIds);

                string[] parameters = userIds.Concat(new string[] { "0" }).ToArray();

                var cr = ContentResolver;
                using (var pCur = cr.Query(Phone.ContentUri, null, selection, parameters, null))
                {
                    var x = pCur.GetColumnNames();
                    var reader2 = new CursorReader<YarlyContact>(pCur, c =>
                    {
                        int numberField = c.GetColumnIndex(Phone.Number);
                        string phoneNo = c.GetString(numberField);

                        return new YarlyContact(null, phoneNo);
                    });

                    foreach (var item in reader2)
                    {
                        try
                        {
                            Console.WriteLine(item);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return;
        }

        private void ToggleProgressBar()
        {
            pBarOn = !pBarOn;

            pBar.Indeterminate = pBarOn;
        }

        public class YarlyContact
        {
            public YarlyContact(string name, string number)
            {
                DisplayName = name;
                Number = number;
            }

            public string DisplayName { get; set; }
            public string Number { get; set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}", DisplayName ?? "no name", Number ?? "no number");
            }
        }

        private class CursorContact
        {
            public CursorContact(ICursor cur)
            {
                var idField = cur.GetColumnIndex(ContactsContract.PhoneLookup.InterfaceConsts.Id);
                var nameField = cur.GetColumnIndex(ContactsContract.PhoneLookup.InterfaceConsts.DisplayName);
                var hasField = cur.GetColumnIndex(ContactsContract.PhoneLookup.InterfaceConsts.HasPhoneNumber);

                Id = cur.GetString(idField);
                DisplayName = cur.GetString(nameField);
                HasPhone = cur.GetString(hasField) != "0";
            }

            public string DisplayName { get; set; }
            public bool HasPhone { get; set; }
            public string Id { get; set; }
        }
    }
}