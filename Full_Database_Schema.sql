-- ============================================
-- Database Schema - Sistem Pakar Profil Lulusan
-- Compatible with MySQL/MariaDB
-- ============================================

-- ============================================
-- REFERENCE TABLES FOR DYNAMIC QUESTIONS
-- ============================================

-- Table untuk menyimpan daftar pertanyaan
CREATE TABLE IF NOT EXISTS ref_questions (
    id_question INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(10) NOT NULL UNIQUE,
    kategori ENUM('A', 'B', 'C') NOT NULL,
    question_text TEXT NOT NULL,
    question_order INT NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Table untuk menyimpan opsi jawaban setiap pertanyaan
CREATE TABLE IF NOT EXISTS ref_question_options (
    id_option INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(10) NOT NULL,
    option_text VARCHAR(255) NOT NULL,
    option_value INT NOT NULL,
    option_order INT NOT NULL,
    CONSTRAINT FK_Option_Question FOREIGN KEY (question_code) REFERENCES ref_questions(question_code) ON DELETE CASCADE,
    INDEX idx_question_code (question_code)
);

-- ============================================
-- INSERT DATA PERTANYAAN KATEGORI A (DATA DIRI)
-- ============================================

-- F_A1: Jenis Kelamin
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A1', 'A', 'Apa jenis kelamin Anda?', 1);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A1', 'Laki-laki', 1, 1),
('F_A1', 'Perempuan', 2, 2);

-- F_A2: Status Pendidikan
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A2', 'A', 'Apa status pendidikan Anda saat ini?', 2);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A2', 'Mahasiswa Aktif', 1, 1),
('F_A2', 'Mahasiswa Non-Aktif / Drop Out', 2, 2),
('F_A2', 'Mahasiswa Cuti', 3, 3);

-- F_A3: Program Studi
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A3', 'A', 'Apa program studi yang sedang Anda tempuh?', 3);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A3', 'Teknik Informatika', 1, 1),
('F_A3', 'Teknik Multimedia Digital', 2, 2),
('F_A3', 'Teknik Multimedia Jaringan', 3, 3);

-- F_A4: Semester
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A4', 'A', 'Anda saat ini berada di semester berapa?', 4);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A4', 'Semester 1', 1, 1),
('F_A4', 'Semester 2', 2, 2),
('F_A4', 'Semester 3', 3, 3),
('F_A4', 'Semester 4', 4, 4),
('F_A4', 'Semester 5', 5, 5),
('F_A4', 'Semester 6', 6, 6),
('F_A4', 'Semester 6+', 7, 7);

-- F_A5: Status Mahasiswa
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A5', 'A', 'Apa status mahasiswa Anda?', 5);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A5', 'Reguler', 1, 1),
('F_A5', 'Paralel', 2, 2),
('F_A5', 'Eksekutif', 3, 3);

-- F_A6: Latar Belakang Pendidikan
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A6', 'A', 'Apa latar belakang pendidikan Anda sebelum kuliah?', 6);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A6', 'SMA IPA', 1, 1),
('F_A6', 'SMA IPS', 2, 2),
('F_A6', 'SMK Teknik', 3, 3),
('F_A6', 'SMK Non-Teknik', 4, 4),
('F_A6', 'Lainnya', 5, 5);

-- F_A7: Alasan Memilih Program Studi
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A7', 'A', 'Apa alasan utama Anda memilih program studi ini?', 7);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A7', 'Minat & Bakat Pribadi', 1, 1),
('F_A7', 'Prospek Kerja yang Baik', 2, 2),
('F_A7', 'Saran Orang Tua / Keluarga', 3, 3),
('F_A7', 'Ikut-ikutan Teman', 4, 4),
('F_A7', 'Pilihan Cadangan', 5, 5);

-- F_A8: Tujuan Kuliah
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A8', 'A', 'Apa tujuan utama Anda kuliah?', 8);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A8', 'Meningkatkan Karir', 1, 1),
('F_A8', 'Mendapatkan Gelar', 2, 2),
('F_A8', 'Menambah Ilmu & Skill', 3, 3),
('F_A8', 'Memperluas Relasi', 4, 4),
('F_A8', 'Mengisi Waktu', 5, 5);

-- F_A9: Metode Belajar Favorit
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A9', 'A', 'Metode belajar apa yang paling Anda sukai?', 9);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A9', 'Diskusi', 1, 1),
('F_A9', 'Membaca', 2, 2),
('F_A9', 'Praktik langsung', 3, 3),
('F_A9', 'Online learning', 4, 4);

-- F_A10: Tingkat Motivasi Belajar
INSERT IGNORE INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A10', 'A', 'Seberapa tinggi motivasi belajar Anda saat ini? (Skala 1-5)', 10);

INSERT IGNORE INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A10', '1 - Sangat Rendah', 1, 1),
('F_A10', '2 - Rendah', 2, 2),
('F_A10', '3 - Cukup', 3, 3),
('F_A10', '4 - Tinggi', 4, 4),
('F_A10', '5 - Sangat Tinggi', 5, 5);

-- ============================================
-- MAIN APPLICATION TABLES
-- ============================================

-- Table Users
CREATE TABLE IF NOT EXISTS users (
    id_user INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    nama_lengkap VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Table Student Profiles (Kategori A - Data Diri)
CREATE TABLE IF NOT EXISTS student_profiles (
    id_profile INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL UNIQUE,
    jenis_kelamin ENUM('L', 'P') NOT NULL,
    status_pendidikan ENUM('Aktif', 'Non-aktif', 'Cuti') DEFAULT 'Aktif',
    program_studi ENUM('Teknik Informatika', 'Teknik Multimedia Digital', 'Teknik Multimedia Jaringan') NOT NULL,
    semester ENUM('1', '2', '3', '4', '5', '6', '6+') NOT NULL,
    status_mahasiswa ENUM('Reguler', 'Paralel', 'Eksekutif') DEFAULT 'Reguler',
    latar_belakang ENUM('SMA IPA', 'SMA IPS', 'SMK Teknik', 'SMK Non-Teknik', 'Lainnya'),
    alasan_memilih_prodi ENUM('Minat pribadi', 'Peluang kerja', 'Saran keluarga', 'Mengikuti teman', 'Lainnya'),
    tujuan_kuliah ENUM('Meningkatkan karir', 'Mendapatkan skill teknis', 'Mengikuti passion', 'Mencari prestasi', 'Tidak yakin'),
    metode_belajar ENUM('Diskusi', 'Membaca', 'Praktik langsung', 'Online learning'),
    motivasi_belajar TINYINT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT FK_Student_User FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE
);

-- Table Academic Data (Kategori B - Data Akademis)
CREATE TABLE IF NOT EXISTS academic_data (
    id_academic INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    ipk DECIMAL(3,2),
    tren_ipk ENUM('Meningkat', 'Stabil', 'Menurun'),
    mata_kuliah_disukai VARCHAR(100),
    mata_kuliah_tdk_disukai VARCHAR(100),
    kemampuan_analisis TINYINT,
    kemampuan_coding TINYINT,
    kemampuan_riset TINYINT,
    pengalaman_proyek ENUM('Tidak pernah', 'Pernah 1 proyek', 'Pernah beberapa proyek') DEFAULT 'Tidak pernah',
    akses_fasilitas TINYINT,
    penguasaan_software TINYINT,
    CONSTRAINT FK_Academic_User FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE
);

-- Table Character Data (Kategori C - Data Karakter)
CREATE TABLE IF NOT EXISTS character_data (
    id_character INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    kategori VARCHAR(50) NOT NULL,
    kode_fakta VARCHAR(10) NOT NULL,
    pernyataan TEXT NOT NULL,
    skala TINYINT NOT NULL,
    CONSTRAINT FK_Character_User FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE,
    INDEX idx_user_kode (id_user, kode_fakta)
);

-- Table Rules (Rule Base untuk Forward Chaining)
CREATE TABLE IF NOT EXISTS rules (
    id_rule INT AUTO_INCREMENT PRIMARY KEY,
    kode_rule VARCHAR(10) NOT NULL UNIQUE,
    premis TEXT NOT NULL,
    kesimpulan VARCHAR(50) NOT NULL,
    cf_rule DECIMAL(3,2) NOT NULL,
    deskripsi TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Table Recommendations (Hasil Rekomendasi)
CREATE TABLE IF NOT EXISTS recommendations (
    id_rekomendasi INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    profil_rekomendasi VARCHAR(50) NOT NULL,
    cf_total DECIMAL(5,4) NOT NULL,
    ranking INT,
    detail_perhitungan TEXT,
    tanggal DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_Recommendation_User FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE,
    INDEX idx_user_ranking (id_user, ranking)
);

-- Table untuk menyimpan profil lulusan yang tersedia
CREATE TABLE IF NOT EXISTS profil_lulusan (
    id_profil INT AUTO_INCREMENT PRIMARY KEY,
    nama_profil VARCHAR(50) NOT NULL UNIQUE,
    deskripsi TEXT,
    kompetensi_utama TEXT,
    prospek_karir TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Table untuk log perhitungan (opsional, untuk debugging)
CREATE TABLE IF NOT EXISTS calculation_logs (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    id_rekomendasi INT,
    step_number INT,
    rule_triggered VARCHAR(10),
    cf_value DECIMAL(5,4),
    description TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_Log_User FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE,
    CONSTRAINT FK_Log_Recommendation FOREIGN KEY (id_rekomendasi) REFERENCES recommendations(id_rekomendasi) ON DELETE CASCADE
);

-- ============================================
-- Insert Data Profil Lulusan
-- Jurusan Teknik Informatika dan Komputer - Politeknik Negeri Jakarta
-- Program Studi: D3 Teknik Informatika, D4 Teknik Multimedia Digital, D4 Teknik Multimedia Jaringan
-- ============================================

INSERT IGNORE INTO profil_lulusan (nama_profil, deskripsi, kompetensi_utama, prospek_karir) VALUES
-- Profil Lulusan D3 Teknik Informatika
('Software Developer', 
 'Profesional yang mampu merancang, mengembangkan, dan memelihara aplikasi perangkat lunak berbasis desktop, web, dan mobile sesuai kebutuhan industri.', 
 'Pemrograman (Java, Python, PHP, JavaScript), Algoritma dan Struktur Data, Basis Data, Pemrograman Web, Pemrograman Mobile, Software Engineering, Problem Solving', 
 'Software Engineer, Web Developer, Mobile App Developer, Full Stack Developer, Backend Developer, Frontend Developer'),

('Database Administrator', 
 'Profesional yang bertanggung jawab dalam perancangan, implementasi, pemeliharaan, dan optimasi sistem basis data untuk mendukung operasional organisasi.', 
 'Perancangan Database, SQL, MySQL/PostgreSQL/Oracle, Data Modeling, Backup & Recovery, Performance Tuning, Data Security', 
 'Database Administrator (DBA), Data Engineer, Database Developer, Data Architect, ETL Developer'),

('IT Support Specialist', 
 'Profesional yang memberikan dukungan teknis dan troubleshooting untuk infrastruktur TI, termasuk hardware, software, dan jaringan.', 
 'Troubleshooting Hardware/Software, Instalasi Sistem Operasi, Networking Dasar, Customer Service, Dokumentasi Teknis, Help Desk Management', 
 'IT Support Engineer, Technical Support Specialist, Help Desk Analyst, Desktop Support Technician, IT Technician'),

('Quality Assurance Engineer', 
 'Profesional yang memastikan kualitas produk software melalui pengujian sistematis, identifikasi bug, dan validasi fungsionalitas.', 
 'Software Testing (Manual & Automation), Test Case Design, Bug Tracking, Selenium/Cypress, API Testing, Performance Testing, Agile/Scrum', 
 'QA Engineer, Software Tester, Test Automation Engineer, QA Analyst, SDET (Software Development Engineer in Test)'),

-- Profil Lulusan D4 Teknik Multimedia Digital
('UI/UX Designer', 
 'Profesional kreatif yang merancang antarmuka pengguna yang intuitif dan pengalaman pengguna yang optimal untuk produk digital.', 
 'User Interface Design, User Experience Research, Wireframing, Prototyping, Figma/Adobe XD, Design Thinking, Usability Testing, Visual Design', 
 'UI Designer, UX Designer, Product Designer, Interaction Designer, UX Researcher, Design Lead'),

('Multimedia Developer', 
 'Profesional yang mengembangkan konten multimedia interaktif termasuk animasi, video, audio, dan aplikasi berbasis multimedia.', 
 'Adobe Creative Suite (Photoshop, Illustrator, After Effects, Premiere), Animasi 2D/3D, Video Editing, Motion Graphics, Unity/Unreal Engine', 
 'Multimedia Designer, Motion Graphics Artist, Video Editor, Content Creator, Game Developer, AR/VR Developer'),

('Digital Content Creator', 
 'Profesional yang menciptakan, mengelola, dan mendistribusikan konten digital untuk berbagai platform media sosial dan digital.', 
 'Content Strategy, Social Media Management, Video Production, Copywriting, SEO, Analytics, Photography, Storytelling', 
 'Content Creator, Digital Marketing Specialist, Social Media Manager, Brand Strategist, Creative Director'),

('Game Developer', 
 'Profesional yang merancang dan mengembangkan video game untuk berbagai platform termasuk PC, console, dan mobile.', 
 'Game Design, Unity/Unreal Engine, C#/C++, 3D Modeling, Game Physics, AI untuk Game, Level Design, Game Testing', 
 'Game Programmer, Game Designer, Level Designer, Technical Artist, Game Producer'),

-- Profil Lulusan D4 Teknik Multimedia Jaringan
('Network Engineer', 
 'Profesional yang merancang, mengimplementasikan, dan mengelola infrastruktur jaringan komputer organisasi.', 
 'Routing & Switching (Cisco), Network Design, TCP/IP, VLAN, VPN, Wireless Networking, Network Monitoring, Troubleshooting Jaringan', 
 'Network Engineer, Network Administrator, Network Architect, NOC Engineer, Wireless Network Engineer'),

('Cybersecurity Analyst', 
 'Profesional yang bertanggung jawab melindungi sistem informasi dari ancaman keamanan siber dan memastikan kepatuhan terhadap standar keamanan.', 
 'Security Analysis, Penetration Testing, SIEM, Firewall Management, Incident Response, Risk Assessment, ISO 27001, Ethical Hacking', 
 'Security Analyst, SOC Analyst, Penetration Tester, Security Engineer, Information Security Officer'),

('Cloud Engineer', 
 'Profesional yang merancang, mengelola, dan mengoptimalkan infrastruktur cloud computing untuk mendukung aplikasi dan layanan organisasi.', 
 'AWS/Azure/GCP, Cloud Architecture, Virtualization, Container (Docker/Kubernetes), IaC (Terraform), DevOps, Microservices', 
 'Cloud Engineer, Cloud Architect, DevOps Engineer, Site Reliability Engineer (SRE), Platform Engineer'),

('System Administrator', 
 'Profesional yang bertanggung jawab mengelola, mengkonfigurasi, dan memelihara server serta infrastruktur sistem organisasi.', 
 'Linux/Windows Server, Virtualization (VMware), Active Directory, Shell Scripting, Backup & Disaster Recovery, Server Monitoring', 
 'System Administrator, Linux Administrator, Windows Administrator, Infrastructure Engineer, Data Center Technician'),

-- Profil Lulusan Lintas Program Studi
('Data Analyst', 
 'Profesional yang menganalisis data untuk menghasilkan insight yang mendukung pengambilan keputusan bisnis.', 
 'Data Analysis, SQL, Python/R, Data Visualization (Tableau/Power BI), Statistics, Excel Advanced, Machine Learning Basics', 
 'Data Analyst, Business Intelligence Analyst, Data Scientist, Analytics Consultant, Reporting Analyst'),

('Project Manager IT', 
 'Profesional yang merencanakan, mengeksekusi, dan mengelola proyek teknologi informasi untuk mencapai tujuan organisasi.', 
 'Project Management (PMBOK/Agile/Scrum), Leadership, Stakeholder Management, Risk Management, Budgeting, MS Project/Jira', 
 'IT Project Manager, Scrum Master, Product Owner, Program Manager, Technical Project Manager'),

('Technopreneur', 
 'Lulusan yang mampu mengidentifikasi peluang bisnis berbasis teknologi dan mengembangkan startup atau usaha mandiri di bidang TI.', 
 'Business Model Canvas, Lean Startup, Product Development, Digital Marketing, Financial Management, Pitching, Innovation', 
 'Startup Founder, Tech Entrepreneur, Product Manager, Business Development Manager, Freelance Developer');

-- ============================================
-- Insert Data Rules (18 Rules)
-- Disesuaikan dengan Profil Lulusan PNJ
-- ============================================

-- Hapus rules lama jika ada
DELETE FROM rules WHERE kode_rule LIKE 'R%';

INSERT INTO rules (kode_rule, premis, kesimpulan, cf_rule, deskripsi) VALUES
-- Rules untuk Software Developer
('R1', '{"F_B6":{"operator":">=","value":4},"F_C75":{"operator":">=","value":4}}', 'Software Developer', 0.85, 'Kemampuan coding tinggi dan minat menjadi programmer'),
('R2', '{"F_B6":{"operator":">=","value":3},"F_C96":{"operator":">=","value":4},"F_C72":{"operator":">=","value":3}}', 'Software Developer', 0.80, 'Kemampuan coding menengah, minat pengembangan software tinggi, dan kreativitas problem solving'),
('R3', '{"F_A3":{"operator":"=","value":"Teknik Informatika"},"F_B6":{"operator":">=","value":3},"F_B4":{"operator":"LIKE","value":"%Pemrograman%"}}', 'Software Developer', 0.75, 'Prodi TI, kemampuan coding, dan menyukai mata kuliah pemrograman'),

-- Rules untuk Database Administrator
('R4', '{"F_B5":{"operator":">=","value":3},"F_C73":{"operator":">=","value":4}}', 'Database Administrator', 0.78, 'Kemampuan analisis tinggi dan berpikir logis sistematis'),
('R5', '{"F_B4":{"operator":"LIKE","value":"%Basis Data%"},"F_C56":{"operator":">=","value":4}}', 'Database Administrator', 0.75, 'Menyukai mata kuliah basis data dan kemampuan analisis masalah tinggi'),

-- Rules untuk UI/UX Designer
('R6', '{"F_C64":{"operator":">=","value":4},"F_C79":{"operator":">=","value":4}}', 'UI/UX Designer', 0.85, 'Minat desain tinggi dan minat menjadi designer tinggi'),
('R7', '{"F_A3":{"operator":"=","value":"Teknik Multimedia Digital"},"F_C57":{"operator":">=","value":4},"F_C64":{"operator":">=","value":3}}', 'UI/UX Designer', 0.80, 'Prodi TMD, kreativitas solusi tinggi, dan minat desain'),
('R8', '{"F_C72":{"operator":">=","value":4},"F_C64":{"operator":">=","value":4},"F_C88":{"operator":">=","value":3}}', 'UI/UX Designer', 0.78, 'Kreativitas problem solving, minat desain, dan kemampuan komunikasi'),

-- Rules untuk Network Engineer
('R9', '{"F_C77":{"operator":">=","value":4},"F_A3":{"operator":"=","value":"Teknik Multimedia Jaringan"}}', 'Network Engineer', 0.85, 'Minat network engineer tinggi dan prodi TMJ'),
('R10', '{"F_C77":{"operator":">=","value":3},"F_A9":{"operator":"=","value":"Praktik langsung"},"F_C66":{"operator":">=","value":3}}', 'Network Engineer', 0.78, 'Minat network, metode belajar praktik langsung, suka kerja lapangan'),
('R11', '{"F_C77":{"operator":">=","value":4},"F_C97":{"operator":">=","value":4},"F_C68":{"operator":">=","value":4}}', 'Network Engineer', 0.82, 'Minat network tinggi, multitasking, dan tahan tekanan'),

-- Rules untuk Cybersecurity Analyst
('R12', '{"F_C78":{"operator":">=","value":4},"F_C73":{"operator":">=","value":4}}', 'Cybersecurity Analyst', 0.85, 'Minat keamanan siber tinggi dan berpikir logis sistematis'),
('R13', '{"F_A3":{"operator":"=","value":"Teknik Multimedia Jaringan"},"F_C78":{"operator":">=","value":3},"F_C93":{"operator":">=","value":4}}', 'Cybersecurity Analyst', 0.80, 'Prodi TMJ, minat keamanan siber, dan rasa ingin tahu tinggi'),

-- Rules untuk Data Analyst
('R14', '{"F_C76":{"operator":">=","value":4},"F_C56":{"operator":">=","value":4},"F_B1":{"operator":">=","value":3.20}}', 'Data Analyst', 0.85, 'Minat data analyst tinggi, kemampuan analisis tinggi, IPK baik'),
('R15', '{"F_B7":{"operator":">=","value":4},"F_C73":{"operator":">=","value":4},"F_C93":{"operator":">=","value":4}}', 'Data Analyst', 0.80, 'Kemampuan riset tinggi, berpikir logis, dan rasa ingin tahu tinggi'),

-- Rules untuk Project Manager IT
('R16', '{"F_C61":{"operator":">=","value":4},"F_C85":{"operator":">=","value":4},"F_C89":{"operator":">=","value":4}}', 'Project Manager IT', 0.85, 'Kepemimpinan tinggi, manajemen waktu baik, dan perencanaan kerja baik'),
('R17', '{"F_C88":{"operator":">=","value":4},"F_C60":{"operator":">=","value":4},"F_C61":{"operator":">=","value":3}}', 'Project Manager IT', 0.78, 'Komunikasi interpersonal tinggi, kemampuan presentasi, dan jiwa kepemimpinan'),

-- Rules untuk Multimedia Developer
('R18', '{"F_A3":{"operator":"=","value":"Teknik Multimedia Digital"},"F_C64":{"operator":">=","value":4},"F_C63":{"operator":">=","value":3}}', 'Multimedia Developer', 0.82, 'Prodi TMD, minat desain tinggi, dan minat inovasi teknologi'),
('R19', '{"F_C57":{"operator":">=","value":4},"F_C96":{"operator":">=","value":3},"F_C64":{"operator":">=","value":4}}', 'Multimedia Developer', 0.78, 'Kreativitas tinggi, minat pengembangan software, dan minat desain'),

-- Rules untuk Cloud Engineer
('R20', '{"F_A3":{"operator":"=","value":"Teknik Multimedia Jaringan"},"F_C96":{"operator":">=","value":4},"F_C77":{"operator":">=","value":3}}', 'Cloud Engineer', 0.80, 'Prodi TMJ, minat pengembangan software tinggi, dan minat jaringan'),
('R21', '{"F_C63":{"operator":">=","value":4},"F_C97":{"operator":">=","value":4},"F_B6":{"operator":">=","value":3}}', 'Cloud Engineer', 0.78, 'Minat inovasi teknologi, kemampuan multitasking, dan kemampuan coding'),

-- Rules untuk Technopreneur
('R22', '{"F_C61":{"operator":">=","value":4},"F_C63":{"operator":">=","value":4},"F_C57":{"operator":">=","value":4}}', 'Technopreneur', 0.85, 'Kepemimpinan tinggi, minat inovasi teknologi, dan kreativitas solusi tinggi'),
('R23', '{"F_A8":{"operator":"=","value":"Meningkatkan karir"},"F_C61":{"operator":">=","value":3},"F_C93":{"operator":">=","value":4}}', 'Technopreneur', 0.75, 'Tujuan kuliah meningkatkan karir, jiwa kepemimpinan, dan rasa ingin tahu tinggi');

