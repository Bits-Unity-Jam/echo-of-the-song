using System.Collections.Generic;
using Game.Scripts.Footsteps;
using Unity.Collections;
using UnityEngine;

namespace Game.Scripts.Sounds.FootstepSounds
{
    public class FootstepSoundHolder : MonoBehaviour
    {
        [ SerializeField ]
        private List<AudioClip> stepClips;

        [ SerializeField ]
        private bool isLeftStepFirst;

        [ SerializeField ]
        private AudioSource audioSource;

        [ Range(0, 1) ]
        [ SerializeField ]
        private float pitchMaxAmplitude = 0.2f;

        [ Range(0, 1) ]
        [ SerializeField ]
        private float panMaxAmplitude = 0.3f;

        [ Range(0, 1) ]
        [ SerializeField ]
        private float panMinAmplitude = 0.1f;

        [ ReadOnly ]
        [ SerializeField ]
        private bool isLeftStepNext;

        [SerializeField]
        private PlayerFootstepCreator _playerFootstepCreator;

        //[ Inject ]
        //private void Construct(PlayerFootstepCreator playerFootstepCreator) => _playerFootstepCreator = playerFootstepCreator;

        private void OnValidate() => audioSource ??= GetComponent<AudioSource>();

        private void Start()
        {
            _playerFootstepCreator.OnFootstepMade += HandleFootstepMade;
            isLeftStepNext = isLeftStepFirst;
        }

        private void OnDestroy() => _playerFootstepCreator.OnFootstepMade -= HandleFootstepMade;

        private void HandleFootstepMade()
        {
            if (isLeftStepNext)LeftStep();
            else RightStep();
            
            isLeftStepNext = !isLeftStepNext;
        }

        private void RightStep()
        {
            float randomRightPan = Random.Range(-panMaxAmplitude, -panMinAmplitude);

            PlayStepSound(randomRightPan);
        }

        private void LeftStep()
        {
            float randomLeftPan = Random.Range(+panMinAmplitude, +panMaxAmplitude);

            PlayStepSound(randomLeftPan);
        }

        private void PlayStepSound(float randomPan)
        {
            audioSource.Stop();
            
            float randomPitch = Random.Range(1f - pitchMaxAmplitude, 1f + pitchMaxAmplitude);
            int randomClipNumber = Random.Range(0, stepClips.Count);

            audioSource.panStereo = randomPan;
            audioSource.pitch = randomPitch;
            audioSource.clip = stepClips[randomClipNumber];
            
            audioSource.Play();
        }
    }
}