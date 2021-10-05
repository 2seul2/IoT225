select code as No, math as Mathmatics from student where code<10 order by math
select math,eng,kor,name from student where code<10 order by math
select getdate() as CurrentTime
select distinct name from student
select name from student group by name
select * from student where code between 3.1 and 8.9
select * from  student where code in(1,2,11,12)
select * from student where name LIKE N'%i%'
select top 1 * from student where name='Nine'
select * from student order by code desc
select max(kor) from student where name like N'%번'

select code, '000-0000-0000' as phone , N'서울' as loc1 INTO stu2 from student
create table stu 
(
   code nchar(5) not null,
   phone nchar(14),
   loc1 nvarchar(20)
)
insert into stu 
     select code, '010-1234-5678' as phone , N'경기' as loc1 from student
select * from stu

SELECT s.code,name,phone,loc1,kor,eng,math INTO stu3
   FROM student s INNER JOIN stu t ON s.code=t.code 
select * from stu3

