using UnityEngine;

public class CharacterAnime
{
    private readonly Animator animator;

    public CharacterAnime(Animator animator)
    {
        this.animator = animator;   
    }

    public void Running(Vector3 direction)
    {
        float speed = direction.magnitude;

        animator.SetFloat("Run", speed);
    }
}
