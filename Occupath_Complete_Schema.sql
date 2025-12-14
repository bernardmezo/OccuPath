DROP TABLE IF EXISTS results;
DROP TABLE IF EXISTS responses;
DROP TABLE IF EXISTS assessments;
DROP TABLE IF EXISTS rule_conditions;
DROP TABLE IF EXISTS rules;
DROP TABLE IF EXISTS profil_lulusan;
DROP TABLE IF EXISTS ref_question_options;
DROP TABLE IF EXISTS ref_questions;
DROP TABLE IF EXISTS student_profiles;
DROP TABLE EXISTS users;

---

-- ## ============================================

-- ## TABLE: users

-- ## ============================================

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(64) NOT NULL,
    full_name VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    role VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_username (username),
    INDEX idx_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


INSERT INTO users (username, password, full_name, email, role)
VALUES ('testuser','dummyhash','Test User','test@occupath.com','student');

---

-- ## ============================================

-- ## TABLE: student_profiles (Kategori A – NON CF)

-- ## ============================================

CREATE TABLE student_profiles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    jenis_kelamin ENUM('L','P'),
    status_pendidikan VARCHAR(50),
    program_studi VARCHAR(100),
    semester VARCHAR(10),
    status_mahasiswa VARCHAR(50),
    latar_belakang VARCHAR(100),
    alasan_memilih_prodi VARCHAR(100),
    tujuan_kuliah VARCHAR(100),
    metode_belajar VARCHAR(100),
    motivasi_belajar TINYINT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_user) REFERENCES users(id)
) ENGINE=InnoDB;

---

-- ## ============================================

-- ## TABLE: profil_lulusan

-- ## ============================================

CREATE TABLE profil_lulusan (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nama_profil VARCHAR(100),
    deskripsi TEXT,
    skills_required TEXT,
    prospek_karir TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- Insert profil lulusan sesuai permintaan dengan struktur baru
INSERT INTO profil_lulusan (nama_profil, deskripsi, skills_required, prospek_karir) VALUES
('Frontend Web Developer', 
 'Spesialis dalam mengembangkan antarmuka pengguna website yang interaktif, responsif, dan menarik dengan teknologi web modern.',
 'HTML5, CSS3, JavaScript, React, Vue.js, TypeScript, Responsive Design, UI/UX Principles',
 'Frontend Developer, Web Developer, UI Developer, Frontend Engineer'),

('Backend Web Developer', 
 'Spesialis dalam mengembangkan logika server, API, dan manajemen database untuk mendukung aplikasi web.',
 'Node.js, Python (Django/Flask), Java (Spring), PHP (Laravel), REST API, Database Design, System Architecture',
 'Backend Developer, API Developer, Server-side Developer, Backend Engineer'),

('Fullstack Web Developer', 
 'Profesional yang menguasai pengembangan baik frontend maupun backend untuk membangun aplikasi web lengkap.',
 'Full Stack JavaScript (MERN/MEAN), Python/Django, Database Management, Deployment, DevOps Basics',
 'Full Stack Developer, Web Application Developer, Technical Lead, Software Engineer'),

('Mobile App Developer', 
 'Spesialis dalam mengembangkan aplikasi mobile untuk platform iOS dan/atau Android.',
 'React Native, Flutter, Kotlin (Android), Swift (iOS), Mobile UI/UX, REST APIs, App Store Deployment',
 'Mobile Developer, iOS Developer, Android Developer, Mobile App Engineer'),

('UI/UX Designer', 
 'Spesialis dalam merancang antarmuka dan pengalaman pengguna yang intuitif, estetis, dan mudah digunakan.',
 'User Research, Wireframing, Prototyping, Figma, Adobe XD, Design Systems, Usability Testing',
 'UI Designer, UX Designer, Product Designer, Interaction Designer'),

('Graphic Designer', 
 'Kreator visual yang menghasilkan desain grafis untuk media digital dan cetak.',
 'Adobe Creative Suite (Photoshop, Illustrator), Typography, Color Theory, Layout Design, Branding',
 'Graphic Designer, Visual Designer, Digital Artist, Brand Designer'),

('Game Developer', 
 'Pengembang yang menciptakan game untuk berbagai platform termasuk PC, konsol, dan mobile.',
 'Unity, C#, Game Physics, 3D Modeling Basics, Game Design, Animation, Level Design',
 'Game Programmer, Game Designer, Gameplay Developer, Indie Game Developer'),

('AR/VR Developer', 
 'Spesialis dalam mengembangkan aplikasi Augmented Reality dan Virtual Reality untuk berbagai industri.',
 'Unity 3D, ARCore, ARKit, Blender, 3D Graphics, Spatial Computing, Interactive Experiences',
 'AR Developer, VR Developer, XR Engineer, Immersive Experience Developer'),

('Database Administrator', 
 'Ahli dalam mengelola, mengoptimalkan, dan menjaga keamanan sistem database.',
 'SQL, MySQL, PostgreSQL, Oracle, Database Design, Performance Tuning, Backup & Recovery',
 'DBA, Database Engineer, Data Architect, Database Manager'),

('Data Analyst', 
 'Analis yang mengolah dan menganalisis data untuk menghasilkan insight bisnis yang actionable.',
 'SQL, Python (Pandas), Excel, Data Visualization (Tableau/PowerBI), Statistics, Business Intelligence',
 'Business Analyst, BI Analyst, Data Specialist, Reporting Analyst'),

('Data Scientist', 
 'Ilmuwan data yang menggunakan algoritma statistik dan machine learning untuk memprediksi dan membuat model data.',
 'Python/R, Machine Learning, Statistics, Data Mining, Big Data Tools, Predictive Modeling',
 'Data Scientist, Machine Learning Scientist, AI Specialist, Predictive Analyst'),

('Machine Learning Engineer', 
 'Insinyur yang mengembangkan dan menerapkan model machine learning ke dalam sistem produksi.',
 'Python, TensorFlow, PyTorch, ML Algorithms, Model Deployment, Cloud AI Services',
 'ML Engineer, AI Engineer, Deep Learning Specialist, Algorithm Engineer'),

('Big Data Engineer', 
 'Spesialis dalam membangun dan memelihara infrastruktur data skala besar untuk pemrosesan data masif.',
 'Hadoop, Spark, Kafka, NoSQL, Data Pipelines, Cloud Data Services, ETL Processes',
 'Big Data Engineer, Data Engineer, Data Platform Engineer, ETL Developer'),

('DevOps Engineer', 
 'Insinyur yang mengintegrasikan pengembangan dan operasi untuk mempercepat deployment dengan otomatisasi.',
 'Docker, Kubernetes, CI/CD, AWS/Azure, Linux, Infrastructure as Code, Monitoring',
 'DevOps Engineer, Site Reliability Engineer, Cloud Operations Engineer, Platform Engineer'),

('Cloud Engineer', 
 'Spesialis dalam merancang, mengimplementasikan, dan mengelola solusi infrastruktur cloud.',
 'AWS, Azure, Google Cloud, Cloud Architecture, Networking, Security, Cost Optimization',
 'Cloud Architect, Cloud Developer, Cloud Administrator, Solutions Architect'),

('Network Engineer', 
 'Ahli dalam merancang, mengimplementasikan, dan memelihara infrastruktur jaringan komputer.',
 'TCP/IP, Routing & Switching, Network Security, Cisco Technologies, Firewalls, Wireless Networks',
 'Network Administrator, Network Architect, System Engineer, Network Security Specialist'),

('Cybersecurity Specialist', 
 'Spesialis dalam melindungi sistem informasi dari ancaman dan serangan siber.',
 'Ethical Hacking, Security Analysis, Cryptography, SIEM, Penetration Testing, Risk Assessment',
 'Security Analyst, Ethical Hacker, SOC Analyst, Information Security Consultant'),

('System Analyst', 
 'Analis sistem yang mempelajari kebutuhan bisnis dan merancang solusi teknologi informasi.',
 'Requirements Analysis, System Design, UML, Process Modeling, Business Analysis, Documentation',
 'Systems Analyst, Business Analyst, IT Consultant, Solution Architect'),

('IT Project Manager', 
 'Manajer yang memimpin proyek teknologi informasi dari inisiasi hingga penyelesaian.',
 'Project Management, Agile/Scrum, Risk Management, Budgeting, Team Leadership, Stakeholder Communication',
 'Project Manager, IT Manager, Program Manager, Delivery Manager'),

('Researcher (Computer & Information Science)', 
 'Peneliti dalam bidang ilmu komputer dan informasi yang berkontribusi pada pengembangan pengetahuan.',
 'Research Methodology, Academic Writing, Data Analysis, Programming for Research, Publication',
 'Research Scientist, Academic Researcher, R&D Specialist, Technology Researcher');

---

-- ## ============================================

-- ## TABLE: ref_questions

-- ## ============================================

CREATE TABLE ref_questions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(20) UNIQUE,
    kategori ENUM('A','B','C'),
    question_text TEXT,
    question_type ENUM('single_choice', 'multiple_choice', 'scale', 'text') DEFAULT 'single_choice',
    question_order INT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- ### KATEGORI A (FULL - sesuai permintaan)

INSERT INTO ref_questions VALUES
(NULL,'F_A1','A','Apa jenis kelamin Anda?','single_choice',1,1,NOW()),
(NULL,'F_A2','A','Apa status pendidikan Anda saat ini?','single_choice',2,1,NOW()),
(NULL,'F_A3','A','Apa program studi yang sedang Anda tempuh?','single_choice',3,1,NOW()),
(NULL,'F_A4','A','Anda saat ini berada di semester berapa?','single_choice',4,1,NOW()),
(NULL,'F_A5','A','Apa status mahasiswa Anda?','single_choice',5,1,NOW()),
(NULL,'F_A6','A','Apa latar belakang pendidikan Anda sebelum kuliah?','single_choice',6,1,NOW()),
(NULL,'F_A7','A','Apa alasan utama Anda memilih program studi ini?','single_choice',7,1,NOW()),
(NULL,'F_A8','A','Apa tujuan utama Anda kuliah?','single_choice',8,1,NOW()),
(NULL,'F_A9','A','Metode belajar apa yang paling Anda sukai?','single_choice',9,1,NOW()),
(NULL,'F_A10','A','Seberapa tinggi motivasi belajar Anda saat ini?','scale',10,1,NOW());

-- ### KATEGORI B (FULL – CF)

INSERT INTO ref_questions VALUES
(NULL,'F_B1','B','Minat pada pemrograman?','scale',11,1,NOW()),
(NULL,'F_B2','B','Kepercayaan diri kemampuan coding?','scale',12,1,NOW()),
(NULL,'F_B3','B','Minat database & SQL?','scale',13,1,NOW()),
(NULL,'F_B4','B','Kemampuan analisis data?','scale',14,1,NOW()),
(NULL,'F_B5','B','Minat machine learning / AI?','scale',15,1,NOW()),
(NULL,'F_B6','B','Penguasaan software teknis (tooling)?','scale',16,1,NOW()),
(NULL,'F_B7','B','Pengalaman proyek praktis?','scale',17,1,NOW()),
(NULL,'F_B8','B','Minat jaringan (networking)?','scale',18,1,NOW()),
(NULL,'F_B9','B','Minat keamanan siber?','scale',19,1,NOW()),
(NULL,'F_B10','B','Minat desain UI/UX atau desain grafis?','scale',20,1,NOW());

-- KATEGORI C

INSERT INTO ref_questions VALUES
(NULL,'F_C56','C','Saya mampu menganalisis masalah dengan cepat dan tepat.','scale',21,1,NOW()),
(NULL,'F_C57','C','Saya nyaman bekerja dengan angka dan analisis numerik.','scale',22,1,NOW()),
(NULL,'F_C58','C','Saya berpikir secara logis dan sistematis ketika menyelesaikan masalah.','scale',23,1,NOW()),
(NULL,'F_C59','C','Saya terbiasa melakukan troubleshooting untuk menemukan akar masalah.','scale',24,1,NOW()),
(NULL,'F_C60','C','Saya cepat beradaptasi terhadap teknologi atau tools baru.','scale',25,1,NOW()),
(NULL,'F_C61','C','Saya tertarik mengembangkan ide atau inovasi teknologi baru.','scale',26,1,NOW()),
(NULL,'F_C62','C','Saya memiliki rasa ingin tahu tinggi terhadap hal teknis.','scale',27,1,NOW()),
(NULL,'F_C63','C','Saya tertarik pada bidang pengembangan software.','scale',28,1,NOW()),
(NULL,'F_C64','C','Saya tertarik dengan teknologi cloud, automation, atau infrastruktur.','scale',29,1,NOW()),
(NULL,'F_C65','C','Saya tertarik mempelajari AI, machine learning, atau data science.','scale',30,1,NOW()),
(NULL,'F_C66','C','Saya memiliki kemampuan komunikasi interpersonal yang baik.','scale',31,1,NOW()),
(NULL,'F_C67','C','Saya percaya diri saat melakukan presentasi.','scale',32,1,NOW()),
(NULL,'F_C68','C','Saya mampu memimpin tim dalam suatu tugas atau proyek.','scale',33,1,NOW()),
(NULL,'F_C70','C','Saya mampu melakukan negosiasi ketika diperlukan.','scale',34,1,NOW()),
(NULL,'F_C71','C','Saya nyaman bekerja dalam tim dan berkolaborasi.','scale',35,1,NOW()),
(NULL,'F_C72','C','Saya mampu bekerja secara mandiri tanpa banyak pengawasan.','scale',36,1,NOW()),
(NULL,'F_C73','C','Saya mampu mengerjakan beberapa tugas secara bersamaan (multitasking).','scale',37,1,NOW()),
(NULL,'F_C75','C','Saya mampu mengambil keputusan secara mandiri saat dibutuhkan.','scale',38,1,NOW()),
(NULL,'F_C76','C','Saya teliti saat mengerjakan tugas atau memeriksa detail teknis.','scale',39,1,NOW()),
(NULL,'F_C77','C','Saya disiplin dalam mengikuti aturan dan deadline.','scale',40,1,NOW()),
(NULL,'F_C79','C','Saya mampu mengikuti prosedur teknis dengan sangat akurat.','scale',41,1,NOW()),
(NULL,'F_C81','C','Saya mampu merencanakan langkah kerja secara efektif dan sistematis.','scale',42,1,NOW()),
(NULL,'F_C82','C','Saya mampu mengambil keputusan di situasi yang rumit atau ambigu.','scale',43,1,NOW()),
(NULL,'F_C83','C','Saya mampu menemukan solusi kreatif untuk berbagai masalah.','scale',44,1,NOW()),
(NULL,'F_C84','C','Saya memiliki ketertarikan kuat pada desain visual dan estetika.','scale',45,1,NOW()),
(NULL,'F_C85','C','Saya memiliki ketertarikan pada pengalaman pengguna (UX).','scale',46,1,NOW()),
(NULL,'F_C86','C','Saya peka terhadap kebutuhan dan kenyamanan pengguna (user empathy).','scale',47,1,NOW());

---

-- ## ============================================

-- ## TABLE: ref_question_options

-- ## ============================================

CREATE TABLE ref_question_options (
    id INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(20),
    option_text VARCHAR(100),
    option_value DECIMAL(5,2),
    option_order INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code)
) ENGINE=InnoDB;

-- 1. INSERT OPSI UNTUK PERTANYAAN KATEGORI A (SINGLE_CHOICE)
-- F_A1 - Jenis Kelamin
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A1', 'Laki-laki', 1.00, 1),
('F_A1', 'Perempuan', 2.00, 2);

-- F_A2 - Status Pendidikan
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A2', 'Mahasiswa Aktif', 1.00, 1),
('F_A2', 'Mahasiswa Non-Aktif / Drop Out', 2.00, 2),
('F_A2', 'Mahasiswa Cuti', 3.00, 3);

-- F_A3 - Program Studi
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A3', 'Teknik Informatika', 1.00, 1),
('F_A3', 'Teknik Multimedia Digital', 2.00, 2),
('F_A3', 'Teknik Multimedia dan Jaringan', 3.00, 3),
('F_A3', 'Teknik Komputer Jaringan', 4.00, 4);

-- F_A4 - Semester
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A4', 'Semester 1', 1.00, 1),
('F_A4', 'Semester 2', 2.00, 2),
('F_A4', 'Semester 3', 3.00, 3),
('F_A4', 'Semester 4', 4.00, 4),
('F_A4', 'Semester 5', 5.00, 5),
('F_A4', 'Semester 6', 6.00, 6),
('F_A4', 'Semester 6+ (Lebih dari 6)', 7.00, 7);

-- F_A5 - Status Mahasiswa
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A5', 'Reguler', 1.00, 1),
('F_A5', 'Paralel', 2.00, 2),
('F_A5', 'Eksekutif', 3.00, 3);

-- F_A6 - Latar Belakang Pendidikan
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A6', 'SMA IPA', 1.00, 1),
('F_A6', 'SMA IPS', 2.00, 2),
('F_A6', 'SMK Teknik', 3.00, 3),
('F_A6', 'SMK Non-Teknik', 4.00, 4),
('F_A6', 'Lainnya', 5.00, 5);

-- F_A7 - Alasan Memilih Program Studi
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A7', 'Minat & Bakat Pribadi', 1.00, 1),
('F_A7', 'Prospek Kerja yang Baik', 2.00, 2),
('F_A7', 'Saran Orang Tua / Keluarga', 3.00, 3),
('F_A7', 'Ikut-ikutan Teman', 4.00, 4),
('F_A7', 'Pilihan Cadangan', 5.00, 5);

-- F_A8 - Tujuan Kuliah
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A8', 'Meningkatkan Karir', 1.00, 1),
('F_A8', 'Mendapatkan Gelar', 2.00, 2),
('F_A8', 'Menambah Ilmu & Skill', 3.00, 3),
('F_A8', 'Memperluas Relasi', 4.00, 4),
('F_A8', 'Mengisi Waktu', 5.00, 5);

-- F_A9 - Metode Belajar Favorit
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A9', 'Diskusi', 1.00, 1),
('F_A9', 'Membaca', 2.00, 2),
('F_A9', 'Praktik langsung', 3.00, 3),
('F_A9', 'Online learning', 4.00, 4);

-- F_A10 - Tingkat Motivasi Belajar (skala khusus untuk Kategori A)
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A10', '1 - Sangat Rendah', 1.00, 1),
('F_A10', '2 - Rendah', 2.00, 2),
('F_A10', '3 - Cukup', 3.00, 3),
('F_A10', '4 - Tinggi', 4.00, 4),
('F_A10', '5 - Sangat Tinggi', 5.00, 5);

-- 2. INSERT OPSI SKALA 1-5 UNTUK SEMUA PERTANYAAN SCALE (KATEGORI B & C)
-- Skala untuk Kategori B dan C menggunakan konversi CF: 1=0, 2=0.25, 3=0.5, 4=0.75, 5=1.0
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order)
SELECT question_code,'1',0.00,1 FROM ref_questions 
WHERE question_type='scale' AND (kategori='B' OR kategori='C')
UNION ALL
SELECT question_code,'2',0.25,2 FROM ref_questions 
WHERE question_type='scale' AND (kategori='B' OR kategori='C')
UNION ALL
SELECT question_code,'3',0.50,3 FROM ref_questions 
WHERE question_type='scale' AND (kategori='B' OR kategori='C')
UNION ALL
SELECT question_code,'4',0.75,4 FROM ref_questions 
WHERE question_type='scale' AND (kategori='B' OR kategori='C')
UNION ALL
SELECT question_code,'5',1.00,5 FROM ref_questions 
WHERE question_type='scale' AND (kategori='B' OR kategori='C');

---

-- ## ============================================

-- ## TABLE: rules

-- ## ============================================

CREATE TABLE rules (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rule_code VARCHAR(20),
    profil_lulusan_id INT,
    cf_rule DECIMAL(3,2),
    description TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (profil_lulusan_id) REFERENCES profil_lulusan(id)
) ENGINE=InnoDB;

-- INSERT RULES BARU DENGAN CF DITURUNKAN (MAKSIMAL 0.80)
INSERT INTO rules (rule_code, profil_lulusan_id, cf_rule, description, is_active) VALUES
-- FRONTEND WEB DEVELOPER (id: 1) - 3 rules UNIK
('R_FE1', 1, 0.78, 'IF F_B1 ≥ 4 AND F_C83 ≥ 4 AND F_B10 ≥ 3 THEN Frontend Web Developer', TRUE),
('R_FE2', 1, 0.75, 'IF F_C84 ≥ 4 AND F_C60 ≥ 4 THEN Frontend Web Developer', TRUE),  -- Desain visual + Adaptif
('R_FE3', 1, 0.72, 'IF F_C63 ≥ 4 AND F_C66 ≥ 3 THEN Frontend Web Developer', TRUE),  -- Software dev + Komunikasi

-- BACKEND WEB DEVELOPER (id: 2) - 3 rules UNIK
('R_BE1', 2, 0.78, 'IF F_B1 ≥ 4 AND F_B3 ≥ 4 THEN Backend Web Developer', TRUE),
('R_BE2', 2, 0.75, 'IF F_C58 ≥ 4 AND F_C76 ≥ 4 THEN Backend Web Developer', TRUE),  -- Logis + Teliti
('R_BE3', 2, 0.72, 'IF F_B7 ≥ 4 AND F_C77 ≥ 4 THEN Backend Web Developer', TRUE),  -- Pengalaman + Disiplin

-- FULLSTACK WEB DEVELOPER (id: 3) - 2 rules UNIK
('R_FS1', 3, 0.78, 'IF F_B1 ≥ 4 AND F_B3 ≥ 3 AND F_C60 ≥ 4 THEN Fullstack Web Developer', TRUE),
('R_FS2', 3, 0.75, 'IF F_C63 ≥ 4 AND F_C83 ≥ 4 AND F_C72 ≥ 4 THEN Fullstack Web Developer', TRUE),  -- Software + Kreatif + Mandiri

-- MOBILE APP DEVELOPER (id: 4) - 2 rules UNIK
('R_MOB1', 4, 0.75, 'IF F_B1 ≥ 4 AND F_C60 ≥ 4 AND F_C72 ≥ 4 THEN Mobile App Developer', TRUE),
('R_MOB2', 4, 0.72, 'IF F_C63 ≥ 4 AND F_C83 ≥ 4 AND F_C61 ≥ 3 THEN Mobile App Developer', TRUE),  -- Software + Kreatif + Inovasi

-- UI/UX DESIGNER (id: 5) - 3 rules UNIK 
('R_UI1', 5, 0.80, 'IF F_C85 ≥ 4 AND F_C86 ≥ 4 THEN UI/UX Designer', TRUE),  -- UX + User empathy
('R_UI2', 5, 0.78, 'IF F_B10 ≥ 4 AND F_C66 ≥ 4 THEN UI/UX Designer', TRUE),  -- Minat desain + Komunikasi
('R_UI3', 5, 0.75, 'IF F_C84 ≥ 4 AND F_C86 ≥ 3 THEN UI/UX Designer', TRUE),  -- Desain visual + User empathy

-- GRAPHIC DESIGNER (id: 6) - 3 rules UNIK 
('R_GD1', 6, 0.78, 'IF F_C84 ≥ 4 AND F_C83 ≥ 4 THEN Graphic Designer', TRUE),  -- Desain visual + Kreatif
('R_GD2', 6, 0.75, 'IF F_B10 ≥ 4 AND F_C84 ≥ 3 THEN Graphic Designer', TRUE),  -- Minat desain + Desain visual
('R_GD3', 6, 0.72, 'IF F_C83 ≥ 4 AND F_C61 ≥ 3 THEN Graphic Designer', TRUE),  -- Kreatif + Inovasi

-- GAME DEVELOPER (id: 7) - 2 rules UNIK
('R_GM1', 7, 0.78, 'IF F_B1 ≥ 4 AND F_C83 ≥ 4 THEN Game Developer', TRUE),
('R_GM2', 7, 0.75, 'IF F_C63 ≥ 4 AND F_C61 ≥ 4 THEN Game Developer', TRUE),  -- Software dev + Inovasi

-- AR/VR DEVELOPER (id: 8) - 3 rules UNIK
('R_ARVR1', 8, 0.78, 'IF F_B1 ≥ 4 AND F_C84 ≥ 4 THEN AR/VR Developer', TRUE),  -- Programming + Desain visual
('R_ARVR2', 8, 0.75, 'IF F_C60 ≥ 4 AND F_C83 ≥ 4 THEN AR/VR Developer', TRUE),  -- Adaptif + Kreatif
('R_ARVR3', 8, 0.72, 'IF F_C63 ≥ 4 AND F_C86 ≥ 3 THEN AR/VR Developer', TRUE),  -- Software dev + User empathy

-- DATABASE ADMINISTRATOR (id: 9) - 2 rules UNIK
('R_DB1', 9, 0.78, 'IF F_B3 ≥ 4 AND F_C58 ≥ 4 THEN Database Administrator', TRUE),
('R_DB2', 9, 0.75, 'IF F_C76 ≥ 4 AND F_C79 ≥ 4 THEN Database Administrator', TRUE),  -- Teliti + Akurat

-- DATA ANALYST (id: 10) - 3 rules UNIK 
('R_DA1', 10, 0.80, 'IF F_B4 ≥ 4 AND F_C56 ≥ 4 THEN Data Analyst', TRUE),
('R_DA2', 10, 0.78, 'IF F_C57 ≥ 4 AND F_C62 ≥ 4 THEN Data Analyst', TRUE),  -- Angka + Rasa ingin tahu
('R_DA3', 10, 0.75, 'IF F_B7 ≥ 4 AND F_C76 ≥ 3 THEN Data Analyst', TRUE),  -- Pengalaman + Teliti

-- DATA SCIENTIST (id: 11) - 2 rules UNIK 
('R_DS1', 11, 0.80, 'IF F_B5 ≥ 4 AND F_C65 ≥ 4 THEN Data Scientist', TRUE),
('R_DS2', 11, 0.78, 'IF F_B7 ≥ 4 AND F_C62 ≥ 4 THEN Data Scientist', TRUE),  -- Pengalaman + Rasa ingin tahu

-- MACHINE LEARNING ENGINEER (id: 12) - 2 rules UNIK 
('R_ML1', 12, 0.80, 'IF F_B5 ≥ 4 AND F_B1 ≥ 4 THEN Machine Learning Engineer', TRUE),
('R_ML2', 12, 0.78, 'IF F_C65 ≥ 4 AND F_C56 ≥ 4 THEN Machine Learning Engineer', TRUE),  -- AI interest + Analisis

-- BIG DATA ENGINEER (id: 13) - 2 rules UNIK
('R_BD1', 13, 0.75, 'IF F_B3 ≥ 4 AND F_B5 ≥ 3 THEN Big Data Engineer', TRUE),
('R_BD2', 13, 0.72, 'IF F_C58 ≥ 4 AND F_C64 ≥ 3 THEN Big Data Engineer', TRUE),  -- Logis + Cloud interest

-- DEVOPS ENGINEER (id: 14) - 2 rules UNIK 
('R_DEV1', 14, 0.78, 'IF F_C73 ≥ 4 AND F_C77 ≥ 4 THEN DevOps Engineer', TRUE),
('R_DEV2', 14, 0.75, 'IF F_B7 ≥ 4 AND F_C60 ≥ 3 THEN DevOps Engineer', TRUE),  -- Pengalaman + Adaptif

-- CLOUD ENGINEER (id: 15) - 2 rules UNIK
('R_CLD1', 15, 0.75, 'IF F_B3 ≥ 4 AND F_C64 ≥ 4 THEN Cloud Engineer', TRUE),
('R_CLD2', 15, 0.72, 'IF F_C58 ≥ 4 AND F_C73 ≥ 3 THEN Cloud Engineer', TRUE),  -- Logis + Multitasking

-- NETWORK ENGINEER (id: 16) - 2 rules UNIK 
('R_NET1', 16, 0.78, 'IF F_B8 ≥ 4 AND F_C77 ≥ 4 THEN Network Engineer', TRUE),
('R_NET2', 16, 0.75, 'IF F_C73 ≥ 4 AND F_C76 ≥ 3 THEN Network Engineer', TRUE),  -- Multitasking + Teliti

-- CYBERSECURITY SPECIALIST (id: 17) - 2 rules UNIK
('R_SEC1', 17, 0.78, 'IF F_B9 ≥ 4 AND F_C77 ≥ 4 THEN Cybersecurity Specialist', TRUE),
('R_SEC2', 17, 0.75, 'IF F_C73 ≥ 4 AND F_C76 ≥ 4 THEN Cybersecurity Specialist', TRUE),  -- Multitasking + Teliti

-- SYSTEM ANALYST (id: 18) - 3 rules UNIK 
('R_SA1', 18, 0.78, 'IF F_C56 ≥ 4 AND F_C58 ≥ 4 THEN System Analyst', TRUE),
('R_SA2', 18, 0.75, 'IF F_C66 ≥ 3 AND F_C67 ≥ 4 THEN System Analyst', TRUE),  -- Komunikasi + Presentasi
('R_SA3', 18, 0.73, 'IF F_C81 ≥ 4 AND F_C82 ≥ 4 THEN System Analyst', TRUE),  -- Perencanaan + Keputusan kompleks

-- IT PROJECT MANAGER (id: 19) - 2 rules UNIK 
('R_PM1', 19, 0.80, 'IF F_C68 ≥ 4 AND F_C75 ≥ 4 AND F_C81 ≥ 4 THEN IT Project Manager', TRUE),
('R_PM2', 19, 0.78, 'IF F_C66 ≥ 4 AND F_C70 ≥ 4 THEN IT Project Manager', TRUE),  -- Komunikasi + Negosiasi

-- RESEARCHER (id: 20) - 2 rules UNIK 
('R_RD1', 20, 0.78, 'IF F_C61 ≥ 4 AND F_C62 ≥ 4 THEN Researcher', TRUE),
('R_RD2', 20, 0.75, 'IF F_B7 ≥ 4 AND F_C56 ≥ 3 THEN Researcher', TRUE);  -- Pengalaman + Analisis

---

-- ============================================

-- TABLE: rule_conditions

-- ============================================

CREATE TABLE rule_conditions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rule_id INT,
    question_code VARCHAR(20),
    operator ENUM('>=','>','<','<=','='),
    threshold_value DECIMAL(5,2),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (rule_id) REFERENCES rules(id),
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code)
) ENGINE=InnoDB;

INSERT INTO rule_conditions (rule_id, question_code, operator, threshold_value) VALUES
-- R_FE1
(1, 'F_B1', '>=', 0.75),
(1, 'F_C83', '>=', 0.75),
(1, 'F_B10', '>=', 0.50),

-- R_FE2
(2, 'F_C84', '>=', 0.75),
(2, 'F_C60', '>=', 0.75),

-- R_FE3
(3, 'F_C63', '>=', 0.75),
(3, 'F_C66', '>=', 0.50),

-- R_BE1
(4, 'F_B1', '>=', 0.75),
(4, 'F_B3', '>=', 0.75),

-- R_BE2
(5, 'F_C58', '>=', 0.75),
(5, 'F_C76', '>=', 0.75),

-- R_BE3
(6, 'F_B7', '>=', 0.75),
(6, 'F_C77', '>=', 0.75),

-- R_FS1
(7, 'F_B1', '>=', 0.75),
(7, 'F_B3', '>=', 0.50),
(7, 'F_C60', '>=', 0.75),

-- R_FS2
(8, 'F_C63', '>=', 0.75),
(8, 'F_C83', '>=', 0.75),
(8, 'F_C72', '>=', 0.75),

-- R_MOB1
(9, 'F_B1', '>=', 0.75),
(9, 'F_C60', '>=', 0.75),
(9, 'F_C72', '>=', 0.75),

-- R_MOB2
(10, 'F_C63', '>=', 0.75),
(10, 'F_C83', '>=', 0.75),
(10, 'F_C61', '>=', 0.50),

-- R_UI1
(11, 'F_C85', '>=', 0.75),
(11, 'F_C86', '>=', 0.75),

-- R_UI2
(12, 'F_B10', '>=', 0.75),
(12, 'F_C66', '>=', 0.75),

-- R_UI3
(13, 'F_C84', '>=', 0.75),
(13, 'F_C86', '>=', 0.50),

-- R_GD1
(14, 'F_C84', '>=', 0.75),
(14, 'F_C83', '>=', 0.75),

-- R_GD2
(15, 'F_B10', '>=', 0.75),
(15, 'F_C84', '>=', 0.50),

-- R_GD3
(16, 'F_C83', '>=', 0.75),
(16, 'F_C61', '>=', 0.50),

-- R_GM1
(17, 'F_B1', '>=', 0.75),
(17, 'F_C83', '>=', 0.75),

-- R_GM2
(18, 'F_C63', '>=', 0.75),
(18, 'F_C61', '>=', 0.75),

-- R_ARVR1
(19, 'F_B1', '>=', 0.75),
(19, 'F_C84', '>=', 0.75),

-- R_ARVR2
(20, 'F_C60', '>=', 0.75),
(20, 'F_C83', '>=', 0.75),

-- R_ARVR3
(21, 'F_C63', '>=', 0.75),
(21, 'F_C86', '>=', 0.50),

-- R_DB1
(22, 'F_B3', '>=', 0.75),
(22, 'F_C58', '>=', 0.75),

-- R_DB2
(23, 'F_C76', '>=', 0.75),
(23, 'F_C79', '>=', 0.75),

-- R_DA1
(24, 'F_B4', '>=', 0.75),
(24, 'F_C56', '>=', 0.75),

-- R_DA2
(25, 'F_C57', '>=', 0.75),
(25, 'F_C62', '>=', 0.75),

-- R_DA3
(26, 'F_B7', '>=', 0.75),
(26, 'F_C76', '>=', 0.50),

-- R_DS1
(27, 'F_B5', '>=', 0.75),
(27, 'F_C65', '>=', 0.75),

-- R_DS2
(28, 'F_B7', '>=', 0.75),
(28, 'F_C62', '>=', 0.75),

-- R_ML1
(29, 'F_B5', '>=', 0.75),
(29, 'F_B1', '>=', 0.75),

-- R_ML2
(30, 'F_C65', '>=', 0.75),
(30, 'F_C56', '>=', 0.75),

-- R_BD1
(31, 'F_B3', '>=', 0.75),
(31, 'F_B5', '>=', 0.50),

-- R_BD2
(32, 'F_C58', '>=', 0.75),
(32, 'F_C64', '>=', 0.50),

-- R_DEV1
(33, 'F_C73', '>=', 0.75),
(33, 'F_C77', '>=', 0.75),

-- R_DEV2
(34, 'F_B7', '>=', 0.75),
(34, 'F_C60', '>=', 0.50),

-- R_CLD1
(35, 'F_B3', '>=', 0.75),
(35, 'F_C64', '>=', 0.75),

-- R_CLD2
(36, 'F_C58', '>=', 0.75),
(36, 'F_C73', '>=', 0.50),

-- R_NET1
(37, 'F_B8', '>=', 0.75),
(37, 'F_C77', '>=', 0.75),

-- R_NET2
(38, 'F_C73', '>=', 0.75),
(38, 'F_C76', '>=', 0.50),

-- R_SEC1
(39, 'F_B9', '>=', 0.75),
(39, 'F_C77', '>=', 0.75),

-- R_SEC2
(40, 'F_C73', '>=', 0.75),
(40, 'F_C76', '>=', 0.75),

-- R_SA1
(41, 'F_C56', '>=', 0.75),
(41, 'F_C58', '>=', 0.75),

-- R_SA2
(42, 'F_C66', '>=', 0.50),
(42, 'F_C67', '>=', 0.75),

-- R_SA3
(43, 'F_C81', '>=', 0.75),
(43, 'F_C82', '>=', 0.75),

-- R_PM1
(44, 'F_C68', '>=', 0.75),
(44, 'F_C75', '>=', 0.75),
(44, 'F_C81', '>=', 0.75),

-- R_PM2
(45, 'F_C66', '>=', 0.75),
(45, 'F_C70', '>=', 0.75),

-- R_RD1
(46, 'F_C61', '>=', 0.75),
(46, 'F_C62', '>=', 0.75),

-- R_RD2
(47, 'F_B7', '>=', 0.75),
(47, 'F_C56', '>=', 0.50);

---

-- ============================================
-- TABLE: profil_lulusan_modifiers
-- Kategori A sebagai contextual modifier (NON-CF)
-- ============================================

CREATE TABLE profil_modifiers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    profil_lulusan_id INT NOT NULL,
    kategori_a_code VARCHAR(20) NOT NULL,
    option_value DECIMAL(5,2) NOT NULL,
    modifier DECIMAL(3,2) NOT NULL,
    description VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (profil_lulusan_id) REFERENCES profil_lulusan(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO profil_modifiers (profil_lulusan_id, kategori_a_code, option_value, modifier, description) VALUES
-- Teknik Informatika (F_A3 = 1.00) 
(1, 'F_A3', 1.00, 1.00, 'Frontend Web Developer - Teknik Informatika sesuai'),
(2, 'F_A3', 1.00, 1.00, 'Backend Web Developer - Teknik Informatika sesuai'),
(3, 'F_A3', 1.00, 1.02, 'Fullstack Web Developer - Teknik Informatika cukup sesuai'),
(10, 'F_A3', 1.00, 1.00, 'Data Analyst - Teknik Informatika sesuai'),
(11, 'F_A3', 1.00, 1.02, 'Data Scientist - Teknik Informatika cukup sesuai'),  
(12, 'F_A3', 1.00, 1.02, 'Machine Learning Engineer - Teknik Informatika cukup sesuai'), 
(13, 'F_A3', 1.00, 1.02, 'Big Data Engineer - Teknik Informatika cukup sesuai'), 
(14, 'F_A3', 1.00, 1.02, 'DevOps Engineer - Teknik Informatika cukup relevan'),  

-- Teknik Multimedia Digital (F_A3 = 2.00)
(5, 'F_A3', 2.00, 1.03, 'UI/UX Designer - Multimedia Digital relevan'),  
(6, 'F_A3', 2.00, 1.02, 'Graphic Designer - Multimedia Digital cukup relevan'),  
(7, 'F_A3', 2.00, 1.02, 'Game Developer - Multimedia Digital cukup relevan'), 

-- Teknik Multimedia Jaringan (F_A3 = 3.00) 
(10, 'F_A3', 3.00, 1.03, 'Data Analyst - Multimedia Jaringan relevan'),  
(16, 'F_A3', 3.00, 1.03, 'Network Engineer - Multimedia Jaringan relevan'),  
(17, 'F_A3', 3.00, 1.02, 'Cybersecurity Specialist - Multimedia Jaringan cukup relevan'),  
(14, 'F_A3', 3.00, 1.02, 'DevOps Engineer - Multimedia Jaringan cukup relevan'), 

-- Teknik Komputer Jaringan (F_A3 = 4.00) 
(16, 'F_A3', 4.00, 1.03, 'Network Engineer - Teknik Komputer Jaringan relevan'), 
(17, 'F_A3', 4.00, 1.02, 'Cybersecurity Specialist - Teknik Komputer Jaringan cukup relevan'),  
(9, 'F_A3', 4.00, 1.01, 'Database Administrator - Teknik Komputer Jaringan sedikit relevan'),  

-- Profil Modifiers untuk Latar Belakang (F_A6)
-- SMA IPA (F_A6 = 1.00) 
(10, 'F_A6', 1.00, 1.02, 'SMA IPA - Data Analyst sedikit relevan'),  
(11, 'F_A6', 1.00, 1.03, 'SMA IPA - Data Scientist relevan'),  
(12, 'F_A6', 1.00, 1.03, 'SMA IPA - Machine Learning Engineer relevan'), 

-- SMA IPS (F_A6 = 2.00) 
(1, 'F_A6', 2.00, 0.95, 'SMA IPS - Frontend Web Developer netral'), 
(2, 'F_A6', 2.00, 0.95, 'SMA IPS - Backend Web Developer netral'),  
(11, 'F_A6', 2.00, 0.95, 'SMA IPS - Data Scientist netral'), 
(12, 'F_A6', 2.00, 0.95, 'SMA IPS - Machine Learning Engineer netral'),  

-- SMK Teknik (F_A6 = 3.00) 
(16, 'F_A6', 3.00, 1.03, 'SMK Teknik - Network Engineer relevan'),  
(17, 'F_A6', 3.00, 1.02, 'SMK Teknik - Cybersecurity Specialist cukup relevan'),
(14, 'F_A6', 3.00, 1.02, 'SMK Teknik - DevOps Engineer cukup relevan'),  

-- SMK Non-Teknik (F_A6 = 4.00) 
(5, 'F_A6', 4.00, 1.02, 'SMK Non-Teknik - UI/UX Designer cukup relevan'),  
(6, 'F_A6', 4.00, 1.00, 'SMK Non-Teknik - Graphic Designer netral'),
(11, 'F_A6', 4.00, 0.90, 'SMK Non-Teknik - Data Scientist kurang relevan'); 

-- ============================================

-- TABLE: assessments, responses, results

-- ============================================

CREATE TABLE IF NOT EXISTS assessments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    date_taken DATETIME DEFAULT CURRENT_TIMESTAMP,
    status ENUM('in_progress', 'completed', 'cancelled') DEFAULT 'in_progress',
    completed_at DATETIME NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    INDEX idx_user (user_id),
    INDEX idx_status (status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE responses (
    id INT AUTO_INCREMENT PRIMARY KEY,
    assessment_id INT,
    question_code VARCHAR(20),
    value_input DECIMAL(5,2),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (assessment_id) REFERENCES assessments(id),
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code)
) ENGINE=InnoDB;

CREATE TABLE results (
    id INT AUTO_INCREMENT PRIMARY KEY,
    assessment_id INT,
    profil_lulusan_id INT,
    cf_value DECIMAL(7,5) NULL,
    cf_percentage DECIMAL(5,2),
    ranking INT,
    matched_rules TEXT,
    explanation TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (assessment_id) REFERENCES assessments(id),
    FOREIGN KEY (profil_lulusan_id) REFERENCES profil_lulusan(id)
) ENGINE=InnoDB;