#include "CStrings.h"
#include <iostream>

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
}
