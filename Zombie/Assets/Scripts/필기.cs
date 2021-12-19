
/*
 * 1. 라이트 맵 (Lightmap)
 * 
 * 유니티 Light가 무겁다! -> '최적화 : 제한된 하드웨어 환경에 맞게끔 설정'
 * 유니티 : 실시간 렌더링
 * ex) Model + Material + Shader + Script + Light + 하드웨어 세팅 + ...
 *     -> 매 프레임마다 렌더링 정보 갱신
 *     
 * -> 매 프레임마다 Light 정보를 계산!
 * 
 * 라이트맵
 * static 으로 지정된 오브젝트의 라이트 정보를 미리 구워(Baked)
 * 라이트맵 파일로 저장. -> 실시간 렌더링 X
 * 
 * 
 * 2. Light Mode
 * 1) Real-time 실시간
 * 2) Baked 베이크 (라이트맵을 굽기 위한 빛 정보)
 * 3) Mixed 혼합 (Realtime + Baked)
 * 
 * 
 * 3. 렌더링 정보 (Renderer)
 * - 3D (Mesh Renderer: Mesh, Material, Light)
 * - Shader (셰이더 : 색상 값을 표현하는 기법)
 * - Camera Filter ( ex) Post-processing 등 )
 * 
 * 4. 라이트 정보 (Light)
 * - Light (Directional, Point, Spot, Area)
 * - Environment (Skybox, GI, Fog)
 * - Shadow (Setting)
 * - Reflection (Light정보X Mesh를 통해 반사된 빛으로 영향을 받아 렌더링 = 반사)
 * - Probe (특수한 지점에 라이트를 부각, 일반적인 라이트X)
 * 
 * 5. GI (Global illumanation) 글로벌 일루미네이션
 * 직접광, 다른 물체, 재질, 벽 등에 반사되는 간접광까지 모두 계산하여
 * 현실 기반의 효과를 주는 기법
 * 
 * 
 * 
 * 애니메이션 (Animation, Animator)
 * 
 * Animation : 프레임 단위로 오브젝트의 속성 정보를 변경시킨 파일
 * 
 * Animator : 애니메이션 클립을 조건에 따라 실행될수 있게끔 설계한 파일
 * - Layer      : 겹겹이 쌓는다. 값이 높을수록 먼저 보임.
 * - Parameter  : 애니메이션 클립을 제어하기 위해 사용하는 변수
 * - State      : 상태. 애니메이션 클립을 담는 정보
 * - Transition : 다른 State로 넘어가는 조건을 담고 있는 화살표
 * - Blend Tree : Parameter 수치에 따라 또 다른 State를 실행해주는 State이다.
 * - Threshold  : Blend Tree에서 또 다른 State를 실행하는 임계값.
 * - Avatar Mask: 특정 부위만 애니메이션을 적용할 수 있는 방식.
 *                (Mask: 덮어 씌운다는 의미. 특정 영역만큼을 해당 정보로 보이게 함)
 * - FK         : Forward Kinematics (상위 개체가 움직이면 하위 개체가 따라 움직이게함)
 * - IK         : Inverse Kinematics (하위 개체가 움직이면 상위 개체가 따라 움직이게함)
 * 
 * 
 * 내비게이션 (Navigation)
 * 지정된 위치로 경로를 계산하고 실시간으로 장애물을 피하며 이동하는 인공지능 시스템
 * 
 * 1) NavMesh (내비메시)        : Agent (에이전트)가 걸어 다닐 수 있는 표면
 * 2) NavMesh Agent (에이전트)  : NavMesh (내비메시) 위에서 경로를 계산하고 이동하는 캐릭터
 * 3) NavMesh Obstacle (장애물) : Agent의 경로를 막는 장애물
 * 
 * NavMesh Bake : NavMesh를 구울 맵 위에서 Agent 크기, Obstacle 등을 고려하여
 *                Agent가 이동할 수 있는 부분만 굽는 기능
 * 
 * 
 * 
 */