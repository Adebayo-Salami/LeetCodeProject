#pragma once

#include <iostream>

class CStrings
{
public:
	CStrings() = default;

	void CStringPractice();

private:
	bool ValidateCustomerNo(std::string customerNumber);
};

