#include <iostream>
#include "..\MyHeader.h"
#include <string>
using namespace std;

void ShowClass(Student &st1)
{
    std::cout << "st1.Number : " << st1.number() << "   ";
    std::cout << "st1.Name : " << st1.name() << "   ";
    std::cout << "st1.Age : " << st1.age() << "   ";
    std::cout << "st1.Kor : " << st1.kor() << "   ";
    std::cout << "st1.Eng : " << st1.eng() << "   ";
    std::cout << "st1.Tot : " << st1.tot() << "   ";
    std::cout << "st1.Avg : " << st1.avg() << std::endl;
}

void swap(int* a, int* b)    // 포인터를 사용     Call-by-reference
{
    int c = *a;
    *a = *b; *b = c;
}

void swapRef(int& a, int& b)    // 포인터를 사용하지 않음
{
    int c = a;
    a = b; b = c;
}

int main()
{
    string fname;
    fname = "c:\\Users\\hulklee1\\Documents\\student.csv";

    int num, age, kor, eng;
    char name[100];
    int count = 0;
    Student* stu[100];  // 포인터 : 주소만 있음 (4 byte). == int (4 byte)

    FILE* fp = fopen(fname.c_str(), "r");
    fgets(name, 250, fp); // 첫줄 무시  ==> file read pointer를 다음 줄로 이동
    while (1)
    {
        if(fscanf(fp,"%d %s %d %d %d", &num, name, &age, &kor, &eng) < 1) break;
        stu[count++] = new Student(num, kor, eng, name, age);
        ShowClass(*stu[count-1]);
    }
    //  Class sorting
    for (int i = 0; i < count - 1; i++)
    {
        for (int k = i + 1; k < count; k++)
        {
            if (stu[i]->avg() < stu[k]->avg())
            {
                //swap((int*)&stu[i], (int*)&stu[k]);
                swapRef((int&)stu[i], (int&)stu[k]);
            }
        }
    }
    for (int i = 0; i < count; i++)
    {
        ShowClass(*stu[i]);
    }
}
