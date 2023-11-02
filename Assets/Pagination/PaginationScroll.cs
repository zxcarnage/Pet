using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeDetector))]
[RequireComponent(typeof(Scroller))]
public class PaginationScroll : MonoBehaviour
{
    [SerializeField] private int _pagesCount;
    [SerializeField] private Page _page;
    [SerializeField] private RectTransform _pageContainer;
    [SerializeField] private RectTransform _targetSize;
    [SerializeField] private Arrow[] _arrows;

    public int MaxPage => _pagesCount;

    public event Action<int,int> PageChanged;

    private int PageCounter => _scroller.CurrentPage;
    private Scroller _scroller;
    private SwipeDetector _detector;

    private void Awake()
    {
        _scroller = GetComponent<Scroller>();
        _detector = GetComponent<SwipeDetector>();
    }

    private void OnEnable()
    {
        foreach (var arrow in _arrows)
        {
            arrow.ArrowPressed += OnArrowPressed;
        }

        _detector.SwipeDetected += OnArrowPressed;
    }
    
    private void OnDisable()
    {
        foreach (var arrow in _arrows)
        {
            arrow.ArrowPressed -= OnArrowPressed;
        }
        _detector.SwipeDetected -= OnArrowPressed;
    }

    private void Start()
    {
        InitializePages();
        InitializeScroller();
        InitializeArrows();
    }

    private void InitializeScroller()
    {
        _scroller.Init();
    }

    private void InitializePages()
    {
        for (int i = 0; i < _pagesCount; i++)
        {
            var page = Instantiate(_page, _pageContainer);
            page.Initialize();
            page.Resize(_targetSize);
        }
    }

    private void InitializeArrows()
    {
        PageChanged?.Invoke(PageCounter, _pagesCount);
    }

    private void OnArrowPressed(Direction direction)
    {
        _scroller.Scroll(direction, _targetSize.rect.size, _pagesCount);
        PageChanged?.Invoke(PageCounter, _pagesCount);
    }
}
