void swapValue(int a, int b);   // �Լ��� ����(prototype) ����
void swapRef(int& a, int& b);
void swapRef(int* a, int* b);  

class Point
{
private:
    int x;  // �⺻ ���� ���� �����ڴ� private 
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
    double distance(Point p); // Point p���� �Ÿ�
};

class Point3D : public Point        // 2D Point class ���
{
private:
    int z; // z��

public:
    Point3D(int x = 0, int y = 0, int z = 0) : Point(x, y)
    {
        this->z = z;
    }
    int Z() { return z; }
    void SetZ(int z) { this->z = z; }
    double distance(Point3D p); // Point3D p���� �Ÿ�
};

