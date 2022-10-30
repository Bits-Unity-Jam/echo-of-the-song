using System;
using System.Collections;
using System.Text;
using UnityEngine;


public class Tail
{
   public Coroutine FadingCoroutine;
   public TrailRenderer renderer;
   public Color color;
   public void StopRenderer()
   {
      if (renderer)
      {
         color.a = 1;
         renderer.startColor=color;
         renderer.endColor=color;
         renderer.emitting = false;
         renderer.Clear();
      }
   }

   public void StartRender()
   {
      renderer.emitting = true;
   }
}


public class EchoTrail : MonoBehaviour
{
   public bool Activated { get; set; }
   
   [SerializeField] private TrailRenderer _rendererWhite;
   [SerializeField] private TrailRenderer _rendererRed;
   [SerializeField] private TrailRenderer _rendererYellow;
   [SerializeField] private TrailRenderer _rendererGreen;
   
   [SerializeField] private EchoCollision _echoCollision;
   
   private float _colorStep;
   
   private Tail _redTail;
   private Tail _whiteTail;
   private Tail _greenTail;
   private Tail _yellowTail;

   private Tail _currentTail;


   private float _currentA;

   private void Awake()
   {
      _currentTail = new Tail();
      _redTail = new Tail();
      _whiteTail = new Tail();
      _greenTail = new Tail();
      _yellowTail = new Tail();
      
      _redTail.color=Color.red;
      _redTail.renderer = _rendererRed;
      _redTail.StopRenderer();
      
      _whiteTail.color = Color.white;
      _whiteTail.renderer = _rendererWhite;
      _whiteTail.StopRenderer();
      
      _greenTail.color = Color.green;
      _greenTail.renderer = _rendererGreen;
      _greenTail.StopRenderer();
      
      _yellowTail.color = Color.yellow;
      _yellowTail.renderer = _rendererYellow;
      _yellowTail.StopRenderer();
   }


   private void OnEnable()
   {
      _echoCollision.Intersection += HandleIntersection;
   }

   private void OnDisable()
   {
      _echoCollision.Intersection -= HandleIntersection;
   }

   private void Update()
   {
      if (_currentA > 0 && Activated)
      {
         _currentA-=_colorStep;
      }
   }


   private void HandleIntersection(IntersectionArea area)
   {
      if (!Activated) return;
      _currentTail.renderer.emitting = false;
      
      switch (area)
      {
         case IntersectionArea.Red:
            EmmitRed();
            break;
         case IntersectionArea.White:
            EmmitWhite();
            break;
         case IntersectionArea.Yellow:
            EmmitYellow();
            break;
         case IntersectionArea.Green:
            EmmitGreen();
            break;
      }
   }
   
   IEnumerator Fading(Tail tail)
   {
      Color color = tail.color;
      color.a = _currentA;
      TrailRenderer renderer = tail.renderer;
      while (color.a> 0 && Activated)
      {
         color.a -= _colorStep;
         renderer.startColor=color;
         renderer.endColor=color;
         yield return null;
      }
      tail.StopRenderer();
   }

   private void EmmitWhite()
   {
      _currentTail = _whiteTail;
      ResetFading();
      _currentTail.StartRender();
      _currentTail.FadingCoroutine=StartCoroutine(Fading(_currentTail));
   }

   private void EmmitRed()
   {
      _currentTail = _redTail;
      ResetFading();
      _currentTail.StartRender();
      _currentTail.FadingCoroutine=StartCoroutine(Fading(_currentTail));
   }
   
   private void EmmitYellow()
   {
      _currentTail = _yellowTail;
      ResetFading();
      _currentTail.StartRender();
      _currentTail.FadingCoroutine=StartCoroutine(Fading(_currentTail));
   }
   
   private void EmmitGreen()
   {
      _currentTail = _greenTail;
      ResetFading();
      _currentTail.StartRender();
      _currentTail.FadingCoroutine=StartCoroutine(Fading(_currentTail));
   }
   public void SetLifeTime(float lifeTime)
   {
      _currentA = 0.47f;
      Deactivate();
      _colorStep = (1 / (lifeTime / Time.fixedDeltaTime));
      EmmitWhite();
   }

   private void Deactivate()
   {
      _redTail.StopRenderer();
      _whiteTail.StopRenderer();
      _greenTail.StopRenderer();
      _yellowTail.StopRenderer();
   }

   private void ResetFading()
   {
      if (_currentTail.FadingCoroutine!=null)
      {
         StopCoroutine(_currentTail.FadingCoroutine);
         _currentTail.FadingCoroutine = null;
      }
   }
}
