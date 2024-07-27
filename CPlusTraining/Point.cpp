#include "Point.h"

Point::Point(int x, int y) : x(x), y(y)
{
}

bool Point::operator==(const Point& other) const
{
	return (x == other.x) && (y == other.y);
}

int Point::GetX() const
{
	return x;
}

int Point::GetY() const
{
	return y;
}

void Point::SetX(int x)
{
	this->x = x;
}

void Point::SetY(int y)
{
	this->y = y;
}

std::strong_ordering Point::operator<=>(const Point& other) const
{
	return (x <=> other.x);
}

std::ostream& operator<<(std::ostream& stream, const Point& point)
{
	stream << point.GetX() << " and " << point.GetY() << std::endl;
	return stream;
}
