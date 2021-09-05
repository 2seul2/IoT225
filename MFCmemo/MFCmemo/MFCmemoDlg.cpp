
// MFCmemoDlg.cpp: 구현 파일
//

#include "pch.h"
#include "framework.h"
#include "MFCmemo.h"
#include "MFCmemoDlg.h"
#include "afxdialogex.h"
#include "AboutDlg.h"
#include "CDlgTest.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMFCmemoDlg 대화 상자

CMFCmemoDlg::CMFCmemoDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_MFCMEMO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMFCmemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	//  DDX_Text(pDX, IDC_TB_MEMO1, strMemo);
	DDX_Control(pDX, IDC_TB_MEMO2, CMemo2);
	DDX_Control(pDX, IDC_TB_MEMO1, CMemo1);
}

BEGIN_MESSAGE_MAP(CMFCmemoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_TEST, &CMFCmemoDlg::OnBnClickedBtnTest)
	ON_COMMAND(ID_MNU_VIEW_LOWER, &CMFCmemoDlg::OnMnuViewLower)
	ON_COMMAND(ID_MNU_VIEW_UPPER, &CMFCmemoDlg::OnMnuViewUpper)
	ON_COMMAND(ID_MNU_EXIT, &CMFCmemoDlg::OnMnuExit)
	ON_COMMAND(ID_MNU_VIEW_HEXA, &CMFCmemoDlg::OnMnuViewHexa)
	ON_COMMAND(ID_MNU_FILE_OPEN, &CMFCmemoDlg::OnMnuFileOpen)
	ON_WM_SIZE()
	ON_WM_ACTIVATE()
	ON_BN_CLICKED(IDC_BTN_CALLTEST, &CMFCmemoDlg::OnBnClickedBtnCalltest)
END_MESSAGE_MAP()


// CMFCmemoDlg 메시지 처리기

BOOL CMFCmemoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 시스템 메뉴에 "정보..." 메뉴 항목을 추가합니다.

	// IDM_ABOUTBOX는 시스템 명령 범위에 있어야 합니다.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != nullptr)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 이 대화 상자의 아이콘을 설정합니다.  응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	ShowWindow(SW_SHOW);

	// TODO: 여기에 추가 초기화 작업을 추가합니다.
	((CButton*)GetDlgItem(IDC_RADIO1))->SetState(true);
	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

void CMFCmemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다.  문서/뷰 모델을 사용하는 MFC 애플리케이션의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CMFCmemoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 그리기를 위한 디바이스 컨텍스트입니다.

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 클라이언트 사각형에서 아이콘을 가운데에 맞춥니다.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 아이콘을 그립니다.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// 사용자가 최소화된 창을 끄는 동안에 커서가 표시되도록 시스템에서
//  이 함수를 호출합니다.
HCURSOR CMFCmemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CMFCmemoDlg::OnBnClickedBtnTest()
{
	static int Count = 0;  

	////CString cs,cs1;
	////char buf[1024];
	////char* sp = buf;
	////char *str = "abcdefghijklmnopqrstuvwxyz";
	////for (int i = 0; *(str + i); i++)  // i < strlen(str)    * == []
	////{
	////	// char 배열 및 포인터를 이용한 경우
	////	//sprintf(sp,"%02X ", str[i]);
	////	//while (*sp) sp++;
	////	// CString class를 이용한 경우
	////	cs1.Format("%02X ", str[i]);
	////	if (i % 8 == 0) cs += "\r\n";  // 8문자마다 줄바꿈
	////	cs += cs1;
	////}
	//////CMemo2.SetWindowTextA(buf);
	////CMemo2.SetWindowTextA(cs);

	//char *str = strMemo.GetBuffer();
	// 소문자 ==> 대문자  a~z  ===>  A~Z   : 가장 무지막지한 방법
	//                   (a~z) ===> (a~z) - 0x20

	////int len = CMemo1.GetWindowTextA((buf, 1024);
	////if (Count % 2)  // 2로 나누었을 때 나머지가 있는 경우 : 홀수인 경우
	////{
	////	for (int i = 0; i < len; i++)
	////	{
	////		if ((buf[i] >= 'a') && (buf[i] <= 'z')) buf[i] -= 0x20;  // 대문자로....
	////	}
	////}
	////else  // 짝수인 경우
	////{
	////	for (int i = 0; i < len; i++)
	////	{
	////		if ((buf[i] >= 'A') && (buf[i] <= 'Z')) buf[i] += 0x20;  // 소문자로...
	////	}
	////}
	CString cstr,s1;
	//cstr.;
	////CMemo1.GetWindowTextA(cstr);
	////if(((CButton*)GetDlgItem(IDC_RADIO1))->GetState() == true) s1 = cstr.MakeLower();
	////else if(((CButton*)GetDlgItem(IDC_RADIO2))->GetState() == true) s1 = cstr.MakeUpper();
	//////if(((CButton*)GetDlgItem(IDC_CHECK1))->GetState() == true) s1 = cstr.MakeLower();
	//////if (Count % 2 == 1) s1 = cstr.MakeLower();  // 원본 불변의 법칙
	//////else s1 = cstr.MakeUpper();
	////CMemo2.SetWindowTextA(s1);
	Count++;
}

void CMFCmemoDlg::OnMnuViewLower()
{
	CString cstr,s1;
	CMemo1.GetWindowTextA(cstr);
	s1 = cstr.MakeLower();
	CMemo2.SetWindowTextA(s1);
}

void CMFCmemoDlg::OnMnuViewUpper()
{
	CString cstr,s1;
	CMemo1.GetWindowTextA(cstr);
	s1 = cstr.MakeUpper();
	CMemo2.SetWindowTextA(s1);
}

void CMFCmemoDlg::OnMnuViewHexa()
{
	CString cstr,cs1,cs;
	CMemo1.GetWindowTextA(cstr);
	char* str = cstr.GetBuffer();  // signed char*   
	int IlIl = 10;
	for (int i = 0; *(str + i); i++)  // i < strlen(str)    * == []
	{		
		// CString class를 이용한 경우
		cs1.Format("%02X ", (unsigned char)str[i]);
		if (i % 16 == 0) cs += "\r\n";  // 16문자마다 줄바꿈
		cs += cs1;
	}
	//CMemo2.SetWindowTextA(buf);
	CMemo2.SetWindowTextA(cs);
}

void CMFCmemoDlg::OnMnuExit()
{
	EndDialog(0);
}

void CMFCmemoDlg::OnMnuFileOpen()
{
	OPENFILENAME ofn;
	char fName[512];
	HWND hwnd = m_hWnd;
	HANDLE hd;   
	FILE* fp;

	ZeroMemory(&ofn, sizeof(ofn));	// 메모리 Clear  ===> 0
	ofn.lStructSize = sizeof(ofn);
	ofn.hwndOwner = hwnd;
	ofn.lpstrFile = fName;
	// Set lpstrFile[0] to '\0' so that GetOpenFileName does not 
	// use the contents of szFile to initialize itself.
	ofn.lpstrFile[0] = '\0';
	ofn.nMaxFile = sizeof(fName);
	ofn.lpstrFilter = "All\0*.*\0C++ Source\0*.CPP\0";
	ofn.nFilterIndex = 1;
	ofn.lpstrFileTitle = NULL;
	ofn.nMaxFileTitle = 0;
	ofn.lpstrInitialDir = NULL;
	ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;

	// Display the Open dialog box. 

	if (GetOpenFileName(&ofn) == TRUE)
	{
		CString cstr;
		fp = fopen(fName,"r+b");
		char* buf = fName;

		while (fgets(buf, 512, fp) != NULL) cstr += buf; 
		CMemo1.SetWindowTextA(cstr);
	}
}


void CMFCmemoDlg::OnSize(UINT nType, int cx, int cy) // (cx,cy) : client size
{
	CDialogEx::OnSize(nType, cx, cy);

	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
	if (GetDlgItem(IDC_TB_MEMO1) != NULL)
	{
		CMemo1.SetWindowPos(NULL, 5, 5, cx / 2, cy / 2, 0);
		CMemo2.SetWindowPos(NULL, 5, cy / 2 + 5, cx / 2, cy / 2 - 10, 0);
	}
}


void CMFCmemoDlg::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CDialogEx::OnActivate(nState, pWndOther, bMinimized);

	// TODO: 여기에 메시지 처리기 코드를 추가합니다.
	CRect r;	//  Client 영역을 담기 위한 구조체 클래스
	GetClientRect(&r);
	OnSize(0, r.Width(), r.Height());
}


void CMFCmemoDlg::OnBnClickedBtnCalltest()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	//MessageBox("메시지 박스 테스트중입니다\n줄바꿈이 먹을까요?");
	////CDlgTest d;
	////d.DoModal();

	//////CDlgTest *dlg = new CDlgTest();
	//////dlg->DoModal();
	//////CString cstr,cs;
	//////CMemo2.GetWindowTextA(cstr);
	//////dlg->CCombo1.GetWindowTextA(cs); 
	//////cstr += "\r\n" + cs;
	//////dlg->CCombo2.GetWindowTextA(cs); cstr += "\r\n" + cs;
	//////dlg->CCombo3.GetWindowTextA(cs); cstr += "\r\n" + cs;
	//////dlg->CCombo4.GetWindowTextA(cs); cstr += "\r\n" + cs;
	//////dlg->CCombo5.GetWindowTextA(cs); cstr += "\r\n" + cs;
	//////delete dlg;

	CDlgTest dlg;
	dlg.DoModal();
	CString cstr,cs;
	CMemo2.GetWindowTextA(cstr);
	cstr += "\r\n" + dlg.s1;
	cstr += "\r\n" + dlg.s2;
	cstr += "\r\n" + dlg.s3;
	cstr += "\r\n" + dlg.s4;
	cstr += "\r\n" + dlg.s5;
	CMemo2.SetWindowTextA(cstr);
}
