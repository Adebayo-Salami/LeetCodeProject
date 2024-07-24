#pragma once

#include <iostream>

using namespace std;

struct Customer
{
	int ID;
	string Name;
	string Email;
	void Print();
	bool operator == (const Customer& customer) const; //cpp reference .com operator overloading
};

