# DSRPT21_VidanaAgua-GameJam
<div align="center">
<img src="https://user-images.githubusercontent.com/61706438/157252203-82740892-bd1d-4d1d-9833-413231e6834f.png" width="900px"/> 
</div>
Jogo para a DSRPT 21, Game Jam da Fiap 2021

  Vida na água – GameJam
  - Unity3D
  - C#
  
Nesse jogo de plataforma 2.5D tive como desafio aplicar o NavMesh, resolvi usa-lo nos inimigos que ficam pela fase e correm atras do jogador para tentar impedi-lo de prosseguir,
com ele mapeei onde os agentes poderiam andar, e, fiz um pequeno código para fazer eles perseguirem o alvo quando o mesmo estiver próximo.

<div align="center">
  <img src="https://user-images.githubusercontent.com/61706438/157252365-bbd32f57-1ae5-4a7b-a133-7e1b4b41a5f8.png" width="900px"/> 
  <img src="https://user-images.githubusercontent.com/61706438/157252402-ea432a40-6c7c-4aba-8c0e-8fce3bec6096.png" width="900px"/> 
  <img src="https://user-images.githubusercontent.com/61706438/157252419-34ce8143-8b5e-41c7-aad9-94416db9b4f0.png" width="900px"/> 
  <img src="https://user-images.githubusercontent.com/61706438/157252425-2f2cc70f-19ba-4a33-ad18-e2f696ceaf0f.png" width="900px"/> 
  <img src="https://user-images.githubusercontent.com/61706438/157252454-1989b71b-519f-475f-a710-602747f73894.png" width="900px"/> 
</div>





    public GameObject TargetMesh;
    public GameObject redAlert;
    [SerializeField] private float safeDistance;
    private bool isRunning;
    private bool _pegou = false;
    private Animator _anim;


    //NavMesh
    private NavMeshAgent _agent;
    public static NavMeshAgent agentAux;
    private GameObject target;

    void Start()
    {

        _anim = TargetMesh.GetComponent<Animator>();

        isRunning = false;

        _agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        agentAux = _agent;
        redAlert.SetActive(false);

    }

    void Update()
    {
        AnimationChange(isRunning);

        //Quando o alvo passa da safeDistance e o agente o persegue
        if (Vector3.Distance(transform.position, target.transform.position) < safeDistance && !_pegou)
        {
            //Confirma se a variavel não vai travar o agente
            _agent.isStopped = false;
            //Seta o destino para o agente ir, usando a posição do alvo
            _agent.SetDestination(new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z));
            //Troca a variavel de animação
            isRunning = true;
            //Ativa um sprite de exclamação em cima da cabeça do agente
            redAlert.SetActive(true);



        }
        //Caso a variavel _pegou seja verdadeira o agente para e sua animação de corrida também
        else if (Vector3.Distance(transform.position, target.transform.position) < safeDistance && _pegou)
        {
            _agent.isStopped = true;
            isRunning = false;

        }
        //Se nenhuma das condições for atendida o agente se mantem parado e todos variaveis são resetadas
        else
        {
            redAlert.SetActive(false);
            _agent.isStopped = true;
            _agent.ResetPath();
            isRunning = false;


        }
    }

    void AnimationChange(bool isRunning)
    {
        _anim.SetBool("isRunning", isRunning);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Quando colide com o alvo Player
        if (other.gameObject.CompareTag("Player"))
        {
            _pegou = true;
            GameController.Instance.State = GameController.GameStates.GAMEOVER_02;

        }
    }
