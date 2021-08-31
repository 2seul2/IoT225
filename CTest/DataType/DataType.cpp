#include <stdio.h> //C++ 전용 헤더 파일
#include <iostream>
using namespace std;
template <typename A>
A Add(A n1, A n2)
{
    return n1 + n2;
}

template <typename A>
void swapEx(A &n1, A &n2)
{
    A c = n1;
    n1 = n2; n2 = c;
}
int main()
{
    // char, short, int, long, float, double 변수를 선언하고
    // 해당 data type 의 byte 수를 출력하시오.

    int age = 10;
    float pi = 3.141592;
    double dr2 = 1.414;
    double dr1 = pi;
    string s1 = "abcd";
    string s2 = "efgh";
    printf("dr1= %f    dr2 = %f \n", dr1, dr2);
    swapEx<double>(dr1, dr2);
    printf("dr1= %f    dr2 = %f \n", dr1, dr2);

    cout << Add<string>(s1, s2) << endl;

    printf("age = %d    sizeof(age) = %d\n", age, sizeof(age));
    printf("pi= %f    sizeof(pi) = %d \n", pi, sizeof(pi));
    printf("dr2= %f    sizeof(dr2) = %d \n", dr2, sizeof(dr2));

}
