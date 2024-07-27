#pragma once

#include <stdexcept>

using namespace std;

class AccountLocked : public exception
{
public:
	const char* what() const noexcept override {
		return "Your account is locked! Contact the admin.";
	}
};

