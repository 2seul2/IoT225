// C:\Users\hulklee1\source\Repos\IoT225\MFCmemo\MFCmemo\CDlgTest.cpp: 구현 파일
//

#include "pch.h"
#include "MFCmemo.h"
#include "C:\Users\hulklee1\source\Repos\IoT225\MFCmemo\MFCmemo\CDlgTest.h"
#include "afxdialogex.h"


// CDlgTest 대화 상자

IMPLEMENT_DYNAMIC(CDlgTest, CDialogEx)

CDlgTest::CDlgTest(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_TEST, pParent)
{

}

CDlgTest::~CDlgTest()
{
}

void CDlgTest::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO1, CCombo1);
	DDX_Control(pDX, IDC_COMBO2, CCombo2);
	DDX_Control(pDX, IDC_COMBO3, CCombo3);
	DDX_Control(pDX, IDC_COMBO4, CCombo4);
	DDX_Control(pDX, IDC_COMBO5, CCombo5);
}


BEGIN_MESSAGE_MAP(CDlgTest, CDialogEx)
	ON_BN_CLICKED(IDOK, &CDlgTest::OnBnClickedOk)
	ON_WM_ACTIVATE()
END_MESSAGE_MAP()


// CDlgTest 메시지 처리기


void CDlgTest::OnBnClickedOk()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CCombo1.GetWindowTextA(s1);
	CCombo2.GetWindowTextA(s2);
	CCombo3.GetWindowTextA(s3);
	CCombo4.GetWindowTextA(s4);
	CCombo5.GetWindowTextA(s5);

	CDialogEx::OnOK();
}


void CDlgTest::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CDialogEx::OnActivate(nState, pWndOther, bMinimized);

	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
}


BOOL CDlgTest::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.

	////CCombo1.AddString("COM1");
	////CCombo1.AddString("COM2");
	////CCombo1.AddString("COM3");
	////CCombo1.AddString("COM4");
	////CCombo2.AddString("9600");
	////CCombo2.AddString("34800");
	////CCombo2.AddString("115200");

	CCombo1.SetWindowTextA(s1);
	CCombo2.SetWindowTextA(s2);
	CCombo3.SetWindowTextA(s3);
	CCombo4.SetWindowTextA(s4);
	CCombo5.SetWindowTextA(s5);

	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}
