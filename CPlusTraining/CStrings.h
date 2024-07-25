#pragma once

#include <iostream>

class CStrings
{
public:
	CStrings() = default;

	void CStringPractice();

private:
	bool ValidateCustomerNo(std::string customerNumber);
	void HandlingInputErrors(int& variable, const std::string& messag);
	void PlayWithFiles();
	void PlayWithBinaryFiles();
	void PastWork();
};

struct Movie {
	int id;
	std::string title;
	int year;
};