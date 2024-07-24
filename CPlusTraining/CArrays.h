#pragma once

class CArrays
{
public:
	CArrays() = default;

	void ArraysPractice();
	void Array_BubbleSort(int numbers[], size_t size);
	void PrintArray(int numbers[], size_t size);
	int FindNumberInArray(int numbers[], size_t size, int target);
	void DynamicResizing();

private:
	void Swap(int numbers[], int i, int j);
	void Swap(int* first, int* second);
};

