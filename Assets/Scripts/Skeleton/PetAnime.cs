using UnityEngine;

public class PetAnime
{
    private readonly Animator animator;

    public PetAnime(Animator animator)
    {
        this.animator = animator;
    }

    public void Running(bool isRun)
    {
        animator.SetBool("Run", isRun);
    }
}
