Feature: Ordering Answers
In order to show answers reasonably

@mytag
Scenario: The answer to the highest vote gets to the top
	Given there is a question "What's your favorite color?" with the answers
		| Answer | Vote |
		| Green  | 4    |
		| Red    | 5    |

	When you upvote answer Red
		And you upvote answer Green
		And you upvote answer Green
		And you upvote answer Green
	Then the answer Green should be on top


@mytag
Scenario: Votes are tallied correctly
	Given there is a question "What's your favorite color?" with the answers
		| Answer | Vote |
		| Blue   | 40   |
		| Red    | 5    |

	When you upvote answer Red
	Then the answer Red should have 6 votes
		And the answer Blue should have 40 votes
		But the answer Green should have 0 votes