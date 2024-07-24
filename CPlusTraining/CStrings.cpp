#include "CStrings.h"
#include <iostream>
#include "Customer.h"

using namespace std;

void CStrings::CStringPractice()
{
	char name[80] = { 'A', 'D', 'E', 'B', 'A', 'Y', '0', '\0' };
	char name2[8] = "ADEBAYO";
	char lastName[] = "SALAMI";

	strcpy_s(name2, lastName);
	strcat_s(name, lastName);
	cout << strlen(name) << endl;
	cout << name << endl;
	cout << name2 << endl;
	cout << strcmp(name, lastName) << endl;

	string fullName = "ADEBAYO SALAMI";
	auto spaceIndex = fullName.find(' ');
	if (spaceIndex != -1) {
		auto firstName = fullName.substr(0, spaceIndex);
		auto lastName = fullName.substr(spaceIndex + 1);
		cout << isupper(lastName[0]) << endl;
		cout << islower(lastName[0]) << endl;
		cout << isalpha(lastName[0]) << endl;
		cout << isdigit(lastName[0]) << endl;
		cout << isspace(lastName[0]) << endl;
	}

	string str = R"(c:\folder\eded\den\dede'de)";

	Customer customerA{};
	customerA.ID = 1;
	customerA.Name = fullName;
	customerA.Email = "test@test.com";
	customerA.Print();
	auto [id, name, email] { customerA }; // Structural Binding || Destructuring || Unpacking
}

bool CStrings::ValidateCustomerNo(string customerNumber)
{
	int digitsCount = 0;
	int alphaCount = 0;
	for (int i = 0; i < customerNumber.length(); i++) {
		if (isalpha(customerNumber[i]))
			alphaCount++;
		if (isdigit(customerNumber[i]))
			digitsCount++;

		if (digitsCount >= 4 && alphaCount >= 2)
			break;
	}

	return (digitsCount >= 4 && alphaCount >= 2);
}
