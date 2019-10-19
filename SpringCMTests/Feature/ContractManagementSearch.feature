Feature: ContractManagement

As a user,
I should be able to search contract management
so that I can view the different contracts

Scenario:Verify that the user is able to view the contracts
	Given SpringCM page is launched
	When I Search "Contract Management" in the search field
	Then "Contract Management" is displayed in the results label
		And "Contract Management Software | SpringCM" link should be displayed

