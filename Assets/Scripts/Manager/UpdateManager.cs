using UnityEngine;

public class UpdateManager : Singleton<UpdateManager>
{
    // Update�� FixedUpdate �̺�Ʈ ����
    public event System.Action OnUpdateEvent;
    public event System.Action OnFixedUpdateEvent;

    // �� �����Ӹ��� Update �̺�Ʈ ȣ��
    void Update()
    {
        OnUpdateEvent?.Invoke();
    }

    // ���� �����Ӹ��� FixedUpdate �̺�Ʈ ȣ��
    void FixedUpdate()
    {
        OnFixedUpdateEvent?.Invoke();
    }

    // Update ���� ��� �� ���� �޼���
    public void Register(IUpdatable updatable)
    {
        OnUpdateEvent += updatable.OnUpdate;
    }

    public void Unregister(IUpdatable updatable)
    {
        OnUpdateEvent -= updatable.OnUpdate;
    }

    // FixedUpdate ���� ��� �� ���� �޼���
    public void Register(IFixedUpdatable fixedUpdatable)
    {
        OnFixedUpdateEvent += fixedUpdatable.OnFixedUpdate;
    }

    public void Unregister(IFixedUpdatable fixedUpdatable)
    {
        OnFixedUpdateEvent -= fixedUpdatable.OnFixedUpdate;
    }
}
