#include <stdio.h>
#include <conio.h>
int main()
{
	char name[20];// 포인터   ;
	int age = 10;
	int height;
	float factor = 100.0;

	int index = 0;	// while 문의 수행 횟수를 정의
	while (index < 9)
	{
		printf("당신의 이름을 입력하세요 ");
		scanf("%s", name);

		printf("당신의 키를 cm단위로 입력하세요\n나이도 입력해 주세요 ");
		scanf("%d %d", &height, &age);

		printf("안녕하세요.\n %s 씨\n",name);
		printf("반갑습니다.\n");
		printf("저는    %5d   살이에요.\n", age);  // %d 10진 정수
		printf("제 키는 %5d   cm 에요.\n", height);
		printf("제 키는 %5.2f  m 에요.\n", (float)(height)/factor ); // %f 1.7m 
		index++;
	}

	getch();
	return 0;	
}