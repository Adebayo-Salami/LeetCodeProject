#include "Point.h"

Point::Point(int x, int y) : x(x), y(y)
{
}

bool Point::operator==(const Point& other) const
{
	return (x == other.x) && (y == other.y);
}

Point Point::operator+(const Point& second) const
{
	return Point(x + second.x, y + second.y);
}

Point Point::operator+(int second) const
{
	return Point(x + second, y + second);
}

Point& Point::operator+=(const Point& other)
{
	this->x += other.x;
	this->y += other.y;
	return *this;
}

Point& Point::operator=(const Point& other)
{
	x = other.x;
	y = other.y;
	return *this;
}

Point& Point::operator++()
{
	this->x++;
	this->y++;
	return *this;
}

Point Point::operator++(int)
{
	Point copy = *this;
	operator++();
	return copy;
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

std::istream& operator>>(std::istream& stream, Point& point)
{
	int value;
	stream >> value;
	point.SetX(value);
	return stream;
}
