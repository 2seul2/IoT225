#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <conio.h>
#include <time.h>

const int students = 20;
int score()
{
	int i, j, k;
	double average, total;
	double kor[students], eng[students], mat[students];

	srand(time(NULL));
	for (i = 0; i < students; i++)
	{
		kor[i] = (double)((rand() % 1000) + 1) / 10.0; // rand : 난수 발생기 (정수)  0 ~ 100.0   1 ~ 1000 0.1 ~ 100.0
		eng[i] = (double)((rand() % 1000) + 1) / 10.0; // rand : 난수 발생기 (정수)  0 ~ 100.0   1 ~ 1000 0.1 ~ 100.0
		mat[i] = (double)((rand() % 1000) + 1) / 10.0; // rand : 난수 발생기 (정수)  0 ~ 100.0   1 ~ 1000 0.1 ~ 100.0
	}
	//for (i = 0; i < students; i++)
	//{
	//	printf("%.1f  %.1f   %.1f\n", kor[i], eng[i], mat[i]);
	//}
	printf("코스타 IoT 국어 점수 현황\n==============================\n\n개인점수 리스트:\n");
	total = 0.;
	for (i = 0; i < students; i++)
	{
		printf("%7.1f\n", kor[i]); // %7.1f  :  실수 출력의 전체 자리수를 7자리, 소수점 이하 1자리
		total += kor[i];
	}
	average = total / students;
	
	printf("총점 : %7.1f\n", total);
	printf("평균 : %7.1f\n", average);

	return 0;
}
int Good()
{
	int i, j, k;
	char good[5] = "Good";
	char mon[] = "morning";
	char noon[] = "afternoon";
	char even[] = "evening";

	while (1)
	{
		printf("지금 몇시죠? "); scanf("%d", &k);
		if (k>7 && k < 12)
		{
			printf("%s %s \n ", good, mon);
		}
		else if (k < 18)
		{
			printf("%s %s \n ", good, noon);
		}
		else if (k < 23)
		{
			printf("%s %s \n ", good, even);
		}
		else
		{
			printf("Hi!\n ");
		}
	}

	return 0;
}
int PointerTest()
{
	int a[3][2] = { 1, 2, 3, 4, 5, 6 };

	printf("a[0] : %x \n", a[0]);
	printf("a[1] : %x \n", a[1]);
	printf("a[2] : %x \n", a[2]);
	printf("a    : %x \n\n\n\n", a);

	printf("a   : %x \n", a);
	printf("a+1 : %x \n", a + 1);
	printf("a+2 : %x \n", a + 2);

	return 0;
}

// function define 
//     Prototype  :  int str_len(char *str)
// 문자열 str을 받아서 해당 문자열의 길이를 되돌려 줌.
int str_len(char* str)
{
	int ret = 0;
//	while (*(str + ret++)); return ret;
	while (1)
	{
		if (str[ret] != 0) ret++;
		else break;
	}
	return ret;
}

int solution1()
{
	//문1) scanf 함수를 이용하여 문자열을 입력후
	//    해당 문자열을 한 글자씩 공백(_)을 삽입하여
	//	  출력하시오.
	//    > 12345   ==>  1_2_3_4_5
	//문2) scanf 함수를 이용하여 문자열을 입력후
	//     getch() 함수를 이용하여 숫자 키를 누르면
	//	   해당 위치의 문자를 출력하시오

	char buf[100];  //	buffer : 버퍼 : 배열 == 포인터
	int i, j, k;

	printf("문자열을 입력하세요 : "); scanf("%s", buf);
	printf("입력문자열 [%s] 의 길이는 %d 입니다 \n", buf, j = str_len(buf));
	for (i = 0; i < j; i++)
	{
		printf("%c_", buf[i]);
	}

	while (1)
	{
		k = getch() - 0x30;   // 0 ~ 9 숫자키 (    ) 입력
		if (k >= 0 && k <= 9)
		{
			printf("%c", buf[k]);
			continue;
		}
		break;
	}

	return 0;
}

int main()
{
	//score();
	//Good();
	//PointerTest();
	solution1();
}