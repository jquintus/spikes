Feature: Ordering Answers
	In order to show answers reasonably

@mytag
Scenario: The answer to the highest vote gets to the top
	Given there is a question "What's your favorite color?" with the answers
		| Answer | Vote |
		| Green  | 4    |
		| Red    | 5    |

	When you upvote answer Red
	Then the answer Red should be on top
