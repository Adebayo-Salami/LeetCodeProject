#include "CArrays.h"
#include <iostream>

using namespace std;

void CArrays::ArraysPractice() {
    int numbers[] = { 10, 20, 30 };
    auto [x, y, z] = numbers;
    cout << (sizeof(numbers) / sizeof(int)) << endl;
    cout << size(numbers) << endl;

    int numbers2[] = { 30, 20, 10 };
    PrintArray(numbers2, size(numbers2));
    Array_BubbleSort(numbers2, size(numbers2));
    PrintArray(numbers2, size(numbers2));

    // 2x3 Matrix
    const int rows = 2;
    const int columns = 3;
    int matrix[rows][columns] = {
        {11, 12, 13},
        {21, 22, 23}
    };

    for (int row = 0; row < rows; row++)
        for (int col = 0; col < columns; col++)
            cout << matrix[row][col] << endl;

    cout << "Printing in reverse order " << endl;
    int numbers3[] = { 10, 20, 30 };
    int* ptr = numbers3 + (size(numbers3) - 1);
    cout << *ptr << endl;
    int currentPosition = size(numbers3) - 1;
    while (currentPosition >= 0) {
        cout << *ptr-- << endl;
        currentPosition--;
    }

    while (ptr >= numbers3)
        cout << *ptr-- << endl;

    // Stack - get automatic cleanup once object goes out of scope 
    // int numbers[1000]

    // Heap (Free Store) - Developers responsible for memory cleanup - can cause memory leak
    // int* numbers = new int[10];
    // int* number = new int;
    // delete number
    // delete[] numbers;
    // number = nullptr
    // numbers = nullptr

    cout << "Running Dynamic Resizing " << endl;
    DynamicResizing();
}

void CArrays::Array_BubbleSort(int numbers[], size_t size)
{
    for (int i = 0; i < size; i++)
        for (int j = 0, k = 1; k < (size - i); j++, k++)
            if (numbers[j] > numbers[k])
                Swap(numbers, j, k);
}

void CArrays::PrintArray(int numbers[], size_t size)
{
    for (int i = 0; i < size; i++)
        cout << numbers[i] << endl;
}

int CArrays::FindNumberInArray(int numbers[], size_t size, int target)
{
    for (int i = 0; i < size; i++)
        if (numbers[i] == target)
            return i;
    return -1;
}

void CArrays::DynamicResizing()
{
    int* numbers = new int[5];
    int entries = 0;
    int size = 5;

    while (true) {
        cout << "Number: ";
        cin >> numbers[entries++];
        if (cin.fail())
            break;

        if (entries == size) {
            size *= 2;
            int* resizedNumbers = new int[size];
            for (int i = 0; i < entries; i++)
                resizedNumbers[i] = numbers[i];
            delete[] numbers;
            numbers = resizedNumbers;
        }
    }

    cout << "Numbers User entered " << endl;
    for (int i = 0; i < (entries - 1); i++)
        cout << numbers[i] << endl;

    delete[] numbers;
    numbers = nullptr;
}

void CArrays::Swap(int numbers[], int i, int j)
{
    int temp = numbers[i];
    numbers[i] = numbers[j];
    numbers[j] = temp;
}

void CArrays::Swap(int* first, int* second)
{
    int temp = *first;
    *first = *second;
    *second = temp;
}
