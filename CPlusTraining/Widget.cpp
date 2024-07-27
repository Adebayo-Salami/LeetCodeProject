#include "Widget.h"
#include <iostream>

//void Widget::Draw() const
//{
//	std::cout << "Drawing a Widget" << std::endl;
//}

void Widget::Enable()
{
	enabled = true;
}

void Widget::Disabled()
{
	enabled = false;
}

bool Widget::IsEnabled() const
{
	return enabled;
}
