#include "CStrings.h"
#include <iostream>
#include "Customer.h"
#include <fstream>
#include <iomanip>
#include <string>
#include <sstream>
#include "Point.h"

using namespace std;

void CStrings::CStringPractice()
{
	int x = 10, y = 20;
	auto result = x <=> y;
	if (result == strong_ordering::less)
		cout << "Its less" << endl;

	Point pointA{ 10, 20 };
	Point pointB{ 30, 30 };
	cout << "Printing point A (" << pointA << ") and Point B (" << pointB << ")" << endl;

	PlayWithBinaryFiles();
}

bool CStrings::ValidateCustomerNo(string customerNumber)
{
	int digitsCount = 0;
	int alphaCount = 0;
	for (int i = 0; i < customerNumber.length(); i++) {
		if (isalpha(customerNumber[i]))
			alphaCount++;
		if (isdigit(customerNumber[i]))
			digitsCount++;

		if (digitsCount >= 4 && alphaCount >= 2)
			break;
	}

	return (digitsCount >= 4 && alphaCount >= 2);
}

void CStrings::HandlingInputErrors(int& variable, const string& message)
{
begin:
	cout << message;
	cin >> variable;
	if (cin.fail()) {
		cout << "Enter a valid number!" << endl;
		cin.clear();
		cin.ignore(numeric_limits<streamsize>::max(), '\n');
		goto begin;
	}
	else
		return;
}

void CStrings::PlayWithFiles()
{
	//ofstream file;
	//file.open("data.csv");
	//if (file.is_open()) {
	//	// CSV: Comma Seprated Value
	//	file << "id, title, year\n"
	//		<< "1, Terminator 1, 1984\n"
	//		<< "2, Terminator 2, 1991\n";
	//	//file << setw(20) << "Hello" << setw(20) << "World" << endl;
	//	file.close();
	//}

	ifstream file;
    file.open("data.csv");
	if (file.is_open()) {
		string str;
		getline(file, str);
		while (!file.eof()) {
			getline(file, str, ',');
			if (str.empty())
				continue;
			//file >> str;
			cout << str << endl;
			Movie movie;
			movie.id = stoi(str);

			getline(file, str, ',');
			movie.title = str;

			getline(file, str);
			movie.year = stoi(str);

			cout << movie.title << " - " << movie.year;
		}
		file.close();
	}

}

void CStrings::PlayWithBinaryFiles()
{
	//int numbers[] = { 1'000'000, 2'000'000, 3'000'000 };
	////ofstream file("numbers.txt");
	//ofstream file("numbers.dat", ios::binary);
	//if (file.is_open()) {
	///*	for (auto number : numbers)
	//		file << number << endl;*/

	//	file.write(reinterpret_cast<char*>(&numbers), sizeof(numbers));
	//	file.close();
	//}

	int numbers[3];
	ifstream file("numbers.dat", ios::binary);
	if (file.is_open()) {
	/*	file.read(reinterpret_cast<char*>(&numbers), sizeof(numbers));
		file.close();*/

		int number;
		while (file.read(reinterpret_cast<char*>(&number), sizeof(number)))
			cout << number << endl;
		file.close();
	}

	fstream file2;
	file2.open("file.txt", ios::in | ios::out | ios::app | ios::binary);
	if (file.is_open()) {

		file.close();
	}
}

void CStrings::PastWork()
{
	char name[80] = { 'A', 'D', 'E', 'B', 'A', 'Y', '0', '\0' };
	char name2[8] = "ADEBAYO";
	char lastName[] = "SALAMI";

	strcpy_s(name2, lastName);
	strcat_s(name, lastName);
	cout << strlen(name) << endl;
	cout << name << endl;
	cout << name2 << endl;
	cout << strcmp(name, lastName) << endl;

	string fullName = "ADEBAYO SALAMI";
	auto spaceIndex = fullName.find(' ');
	if (spaceIndex != -1) {
		auto firstName = fullName.substr(0, spaceIndex);
		auto lastName = fullName.substr(spaceIndex + 1);
		cout << isupper(lastName[0]) << endl;
		cout << islower(lastName[0]) << endl;
		cout << isalpha(lastName[0]) << endl;
		cout << isdigit(lastName[0]) << endl;
		cout << isspace(lastName[0]) << endl;
	}

	string strPath = R"(c:\folder\eded\den\dede'de)";

	Customer customerA{};
	customerA.ID = 1;
	customerA.Name = fullName;
	customerA.Email = "test@test.com";
	customerA.Print();
	auto [id, name4, email] { customerA }; // Structural Binding || Destructuring || Unpacking

	int first;
	while (true) {
		cout << "First ";
		cin >> first;
		if (cin.fail()) {
			cout << "Ener a valid number!" << endl;
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
		else
			break;
	}

	int second;
	HandlingInputErrors(second, "Second: ");
	cout << "You entered " << first << " and " << second << endl;

	double number = 12.34;
	stringstream stream;
	stream << fixed << setprecision(2) << number;
	string str = stream.str();
	cout << str << endl;

	string str2 = "10 20";
	stream.str(str2);
	int first2;
	stream >> first2;
	int second2;
	stream >> second2;
	cout << first2 + second2;

	string str3 = "Terminator 1,1984";
	stream.str(str3);
	Movie movie3;
	getline(stream, movie3.title, ',');
	string year;
	getline(stream, year);
	movie3.year = stoi(year);
}
