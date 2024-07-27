#pragma once

#include <string>
#include "Widget.h"

class TextBox final : public Widget
{
public:
	//using Widget::Widget;
	TextBox() = default;
	explicit TextBox(bool enabled, const std::string& value);
	std::string GetValue();
	void SetValue(const std::string& value);
	void Draw() const override final;

private:
	std::string value;
};

