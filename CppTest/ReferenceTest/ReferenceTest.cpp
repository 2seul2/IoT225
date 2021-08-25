#include <cstdio>
#include <iostream>
#include "..\MyHeader.h"
using namespace std;

int main()
{
    //cout << "Hello C plus plus World!\n\n";
    //
    //int a, b;
    //a = 10;
    //b = 20;
    //cout << "초기값은  a = " << a << ", b = " << b << endl;
    //swapValue(a, b);
    //cout << "결과값(swapValue)은  a = " << a << ", b = " << b << endl;
    //swapRef(a, b);  // reference type 호출
    //printf("결과값(swapRef:ref)은  a = %d, b = %d \n\n",a,b);
    //swapRef(&a, &b);  // pointer type 호출
    //printf("결과값(swapRef:포인터)은  a = %d, b = %d \n\n",a,b);

    Point p1;   // p(0,0)  struct-->typedef--->사용
    Point p2(10, 20);
    Point* p3 = new Point(20,30);  // 동적 할당
    printf("Point class 변수의 동적 할당 : p3(%d,%d)\n\n", p3->X(), p3->Y());
    printf("두 점 p1(%d,%d)과 p2(%d,%d)의 거리는 %f 입니다\n", p1.X(), p1.Y(), p2.X(), p2.Y(), p1.distance(p2));

    Point3D pp1;
    Point3D pp2(10,20,30);
    Point3D *pp3 = new Point3D(40,50,60);
    printf("Point3D class 변수의 동적 할당 : pp3(%d,%d,%d)\n\n", pp3->X(), pp3->Y(),pp3->Z());
    printf("두 점 pp1(%d,%d,%d)과 pp2(%d,%d,%d)의 거리는 %f 입니다\n", 
        pp3->X(), pp3->Y(), pp3->Z(), pp2.X(), pp2.Y(), pp2.Z(), pp2.distance(*pp3));
}
