#include "TextBox.h"
#include <iostream>

//TextBox::TextBox(bool enabled) : Widget(enabled)
//{
//
//}

//TextBox::TextBox(bool enabled, const std::string& value) : Widget(enabled), value(value)
TextBox::TextBox(bool enabled, const std::string& value) : value(value)
{

}

std::string TextBox::GetValue()
{
	return value;
}

void TextBox::SetValue(const std::string& value)
{
	this->value = value;
}

void TextBox::Draw() const
{
	//Widget::Draw();
	std::cout << "Drawing a Text Box" << std::endl;
}
