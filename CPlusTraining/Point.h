#pragma once

#include <compare>
#include <ostream>
#include <istream>

class Point
{
public:
	explicit Point(int x, int y);

	
	int GetX() const;
	int GetY() const;

	void SetX(int x);
	void SetY(int y);

	bool operator==(const Point& other) const;
	std::strong_ordering operator<=>(const Point& other) const;
	friend std::ostream& operator<<(std::ostream& stream, const Point& point);
	Point operator+(const Point& second) const;
	Point operator+(int second) const;

private:
	int x;
	int y;
};

std::ostream& operator<<(std::ostream& stream, const Point& point);
std::istream& operator>>(std::istream& stream, Point& point);