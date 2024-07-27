#include "Widget.h"

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
