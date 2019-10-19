Feature: ContractManagementDemo

As a user,
I should be able to click play video button
so that I can view the demo videos

Scenario: Verify user is able to see the contract management demo 
	Given "Contract Software Management" links are displayed
	When I click on "Contract Management Software" link
	Then "Contract Management Software" home page is displayed
	When I click on "product demo" link in contract management page
	Then "Contract Management Demo" page is displayed
	When I click on "Play Video" button
	Then Validation messages are displayed
	When I fill the form
	| firstName | lastName | emailId  | phone      | companyName | country |
	| Kombaiya  | Pillai   | k@ct.com | 1234567890 | CVS         | US      |
		And I click on "Play Video" button
	Then video player for product demo is displayed
