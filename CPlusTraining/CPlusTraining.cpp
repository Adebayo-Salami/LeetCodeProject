// CPlusTraining.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "CArrays.h"
#include "CStrings.h"
#include "interval_map.h"

int main()
{
	//CArrays().ArraysPractice();
	//CStrings().CStringPractice();

	interval_map<int, char> imap('A');
	imap.assign(1, 5, 'B');
	imap.assign(2, 4, 'C');
	auto resul = imap[0];
	resul = imap[1];
	resul = imap[2];
	resul = imap[3];
	resul = imap[4];
	resul = imap[5];
	resul = imap[-1];
}