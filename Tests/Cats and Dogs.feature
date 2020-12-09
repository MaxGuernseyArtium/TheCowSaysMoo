Feature: Animals

Scenario Template: Rendering to text
	Given rendering to text
	And the animal is a <Animal>
	When the animal speaks
	Then the output is:
"""
The <Animal> says '<Says>'.
"""
Scenarios:
	| Animal | Says |
	| cat    | meow |
	| dog    | woof |
	| cow    | moo  |

Scenario Template: Rendering to JSON
	Given rendering to json
	And the animal is a <Animal>
	When the animal speaks
	Then the output is:
"""
{
  "animal":"<Animal Code>",
  "says":"<Says>"
}
"""
Scenarios:
	| Animal | Animal Code | Says |
	| cat    | Cat         | meow |
	| dog    | Dog         | woof |
	| cow    | Cow         | moo  |
