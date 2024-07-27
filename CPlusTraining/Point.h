#pragma once

#include <compare>
#include <ostream>

class Point
{
public:
	explicit Point(int x, int y);
	bool operator==(const Point& other) const;
	int GetX() const;
	int GetY() const;
	void SetX(int x);
	void SetY(int y);
	std::strong_ordering operator<=>(const Point& other) const;

private:
	int x;
	int y;
};

std::ostream& operator<<(std::ostream& stream, const Point& point);