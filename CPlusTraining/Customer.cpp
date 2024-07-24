#include "Customer.h"

void Customer::Print()
{
	cout << "ID: " << ID << endl
		<< "Name: " << Name << endl
		<< "Email:" << Email << endl;
}

bool Customer::operator==(const Customer& customer) const
{
	return (ID == customer.ID && Name == customer.Name && Email == customer.Email);
}
