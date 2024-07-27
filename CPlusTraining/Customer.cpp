#include "Customer.h"

#include <iostream>

template<typename T>
T Larger(T first, T second) {
	return (first > second) ? first : second;
}

template<typename K, typename V>
void Display(K key, V value) {
	std::cout << key << " = " << value << std::endl;
}


void Customer::Print()
{
	cout << "ID: " << ID << endl
		<< "Name: " << Name << endl
		<< "Email:" << Email << endl;
}

bool Customer::operator == (const Customer& customer) const
{
	return (ID == customer.ID && Name == customer.Name && Email == customer.Email);
}

ostream& operator << (ostream& stream, const Customer& customer) {
	stream << customer.ID << endl;
	return stream;
}