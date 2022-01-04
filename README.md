# DSRPT21_VidanaAgua-GameJam
Jogo para a DSRPT 21, Game Jam da Fiap 2021

  Vida na água – GameJam
  
Nesse jogo de plataforma 2.5D tive como desafio aplicar o NavMesh, resolvi usa-lo nos inimigos que ficam pela fase e correm atras do jogador para tentar impedi-lo de prosseguir,
com ele mapeei onde os agentes poderiam andar, e, fiz um pequeno código para fazer eles perseguirem o alvo quando o mesmo estiver próximo.




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
