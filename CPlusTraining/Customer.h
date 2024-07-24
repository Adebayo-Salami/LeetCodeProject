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

ostream& operator << (ostream& stream, const Customer& customer) {
	stream << customer.ID << endl;
	return stream;
}

enum CustomerStatus {
	PAYING = 1,
	OWNING,
	PAID
};

enum class CustomerStatus2 {
	PAYING = 1,
	OWNING,
	PAID
};