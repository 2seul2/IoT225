
// MFCApp1View.cpp: CMFCApp1View 클래스의 구현
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS는 미리 보기, 축소판 그림 및 검색 필터 처리기를 구현하는 ATL 프로젝트에서 정의할 수 있으며
// 해당 프로젝트와 문서 코드를 공유하도록 해 줍니다.
#ifndef SHARED_HANDLERS
#include "MFCApp1.h"
#endif

#include "MFCApp1Doc.h"
#include "MFCApp1View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCApp1View

IMPLEMENT_DYNCREATE(CMFCApp1View, CEditView)

BEGIN_MESSAGE_MAP(CMFCApp1View, CEditView)
	// 표준 인쇄 명령입니다.
	ON_COMMAND(ID_FILE_PRINT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CMFCApp1View::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
	ON_COMMAND(ID_ZOOMIN, &CMFCApp1View::OnZoomin)
	ON_COMMAND(ID_ZOOMOUT, &CMFCApp1View::OnZoomout)
END_MESSAGE_MAP()

// CMFCApp1View 생성/소멸

CMFCApp1View::CMFCApp1View() noexcept
{
	// TODO: 여기에 생성 코드를 추가합니다.

}

CMFCApp1View::~CMFCApp1View()
{
}

BOOL CMFCApp1View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: CREATESTRUCT cs를 수정하여 여기에서
	//  Window 클래스 또는 스타일을 수정합니다.

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL);	// 자동 래핑을 사용합니다.

	return bPreCreated;
}


// CMFCApp1View 인쇄


void CMFCApp1View::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CMFCApp1View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 기본적인 CEditView 준비
	return CEditView::OnPreparePrinting(pInfo);
}

void CMFCApp1View::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 기본 CEditView 시작 인쇄
	CEditView::OnBeginPrinting(pDC, pInfo);
}

void CMFCApp1View::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 기본 CEditView 종료 인쇄
	CEditView::OnEndPrinting(pDC, pInfo);
}

void CMFCApp1View::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CMFCApp1View::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CMFCApp1View 진단

#ifdef _DEBUG
void CMFCApp1View::AssertValid() const
{
	CEditView::AssertValid();
}

void CMFCApp1View::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CMFCApp1Doc* CMFCApp1View::GetDocument() const // 디버그되지 않은 버전은 인라인으로 지정됩니다.
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMFCApp1Doc)));
	return (CMFCApp1Doc*)m_pDocument;
}
#endif //_DEBUG


// CMFCApp1View 메시지 처리기
static int fSize = 14;
CFont tf;
void CMFCApp1View::OnZoomin()
{
	// TODO: 여기에 명령 처리기 코드를 추가합니다.
	// Client 영역의 문자 크기를 확대
	LOGFONT lf;
	//ZeroMemory(&lf, sizeof(lf));
	//lf.lfHeight = fSize++;
	if (GetFont() == NULL)
	{
		CFont* pFont = CFont::FromHandle((HFONT)GetStockObject(DEFAULT_GUI_FONT));
		pFont->GetLogFont(&lf);
	}
	else GetFont()->GetLogFont(&lf);
	if (lf.lfHeight < 0) lf.lfHeight = abs(lf.lfHeight);
	lf.lfHeight++;

	//CFont* cf = new CFont;
	//cf->DeleteObject();
	//cf->CreateFontIndirect(&lf);
	tf.DeleteObject();
	tf.CreateFontIndirect(&lf);
	SetFont(&tf);
}

void CMFCApp1View::OnZoomout()
{
	// TODO: 여기에 명령 처리기 코드를 추가합니다.
	// Client 영역의 문자 크기를 축소
	LOGFONT lf;
	GetFont()->GetLogFont(&lf);
	lf.lfHeight--;

	tf.DeleteObject();
	tf.CreateFontIndirect(&lf);
	SetFont(&tf);
}
