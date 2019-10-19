Feature: ResourceLibrary
	As a user,
	I should be able to filter resourc library
	so that I can view only desired contents

Scenario: Verify that user is able to view resource library
	Given SpringCM page is launched
	When I select "Resource Library" under Resource tab
	Then the default resource content is displayed
	When I select Media type drop down
	Then media type drop down is displayed
	When I select "Reports" from media type drop down
	Then only "Report" content is displayed on resource page