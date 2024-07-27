#pragma once
class Widget
{
public:
	void Enable();
	void Disabled();
	bool IsEnabled() const;

private:
	bool enabled;
};

