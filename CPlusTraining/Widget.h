#pragma once

class Widget
{
public:
	virtual ~Widget() = default;
	virtual void Draw() const = 0;	// = 0  Makes its a Pure virtual method transforming to an abstract class and cannot be instatiated
	void Enable();
	void Disabled();
	bool IsEnabled() const;

private:
	bool enabled;

protected:
	int width;
};

