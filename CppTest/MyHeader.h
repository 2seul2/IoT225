void swapValue(int a, int b);   // 함수의 원형(prototype) 선언
void swapRef(int& a, int& b);
void swapRef(int* a, int* b);  

class Point
{
private:
    int x;  // 기본 접근 제어 지시자는 private 
    int y;

public:
    Point(int x = 0, int y = 0) : x(x)
    {
        this->y = y;
    }
    int X() { return x; }
    int Y() { return y; }
    void SetX(int x) { this->x = x; }
    void SetY(int y) { this->y = y; }
    double distance(Point p); // Point p와의 거리
};

class Point3D : public Point        // 2D Point class 상속
{
private:
    int z; // z축

public:
    Point3D(int x = 0, int y = 0, int z = 0) : Point(x, y)
    {
        this->z = z;
    }
    int Z() { return z; }
    void SetZ(int z) { this->z = z; }
    double distance(Point3D p); // Point3D p와의 거리
};

