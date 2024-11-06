using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Service.Window.Runtime.Api;
using UnityEngine;
using UnityEngine.UI;

namespace Game.States
{
	public class FaderWindow : Window, ICommonWindow
	{
		public List<GameObject> animatedObjects;
		public Ease _ease;
		public float timeToMoveInSeconds = 2;
		public float _durationFade = 0.3f;
		public float _durationUnFade = 0.3f;

		private Dictionary<GameObject, Vector3> _animatedObjectsDefaultPosition = new();
		private TweenerCore<Vector3, Vector3, VectorOptions> _tweens;
		private List<MaskableGraphic> _fadedImages;
		private Dictionary<MaskableGraphic, float> _graphicsDefaultAlpha = new();

		public UniTask Initialize()
		{
			foreach (GameObject animatedObject in animatedObjects) _animatedObjectsDefaultPosition.Add(animatedObject, animatedObject.transform.localPosition);
			_fadedImages = transform.GetComponentsInChildren<MaskableGraphic>().ToList();
			foreach (MaskableGraphic graphic in _fadedImages) _graphicsDefaultAlpha.Add(graphic, graphic.color.a);
			ImageUnFade(0);
			
			return UniTask.CompletedTask;
		}

		public UniTask Show() => Fade();

		public UniTask Close() => UnFade();
		public void Dispose() => StopAllAnimation();

		[ContextMenu("Fade")]
		private async UniTask Fade()
		{
			foreach (MaskableGraphic graphic in _fadedImages) graphic.DOFade(_graphicsDefaultAlpha[graphic], _durationFade);
			StartAnimation();
			await UniTask.WaitForSeconds(_durationFade);
		}

		[ContextMenu("UnFade")]
		private async UniTask UnFade()
		{
			ImageUnFade(_durationUnFade);
			await UniTask.WaitForSeconds(_durationUnFade);
			StopAllAnimation();
		}

		private void ImageUnFade(float durationUnFade)
		{
			foreach (MaskableGraphic image in _fadedImages) image.DOFade(0, durationUnFade);
		}

		[ContextMenu("StartAnimation")]
		private void StartAnimation()
		{
			SetDefaultPositionToAnimatedObjects();

			foreach (GameObject ball in animatedObjects) TweenMove(ball);
		}

		[ContextMenu("StopAllAnimation")]
		private void StopAllAnimation()
		{
			var tweens = new List<Tween>();
			foreach (GameObject animatedObject in animatedObjects) tweens.AddRange(DOTween.TweensByTarget(animatedObject.transform, true));

			foreach (Tween tween in tweens) tween.Kill();
		}

		private void SetDefaultPositionToAnimatedObjects()
		{
			foreach (GameObject animatedObject in _animatedObjectsDefaultPosition.Keys)
				animatedObject.transform.localPosition = _animatedObjectsDefaultPosition[animatedObject];
		}

		private void TweenMove(GameObject animatedObject)
		{
			Vector3 endPosition = animatedObject.transform.localPosition;
			endPosition.z *= -1;
			animatedObject.transform.localPosition = endPosition;
			endPosition.x *= -1;
			TweenerCore<Vector3, Vector3, VectorOptions> tween = animatedObject.transform.DOLocalMove(endPosition, timeToMoveInSeconds);
			tween.SetEase(_ease);
			tween.onComplete += () => TweenMove(animatedObject);
		}
	}
}