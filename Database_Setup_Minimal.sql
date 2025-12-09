-- ============================================
-- OCCUPATH - MINIMAL DATABASE SETUP FOR UI TESTING
-- ============================================
-- Database: db_occupath
-- Purpose: Minimal schema untuk testing UI/frontend
-- No complex backend logic, just structure
-- ============================================

-- Drop existing tables if exists (optional, untuk fresh start)
-- DROP TABLE IF EXISTS results;
-- DROP TABLE IF EXISTS responses;
-- DROP TABLE IF EXISTS assessments;
-- DROP TABLE IF EXISTS rule_conditions;
-- DROP TABLE IF EXISTS rules;
-- DROP TABLE IF EXISTS profil_lulusan;
-- DROP TABLE IF EXISTS ref_question_options;
-- DROP TABLE IF EXISTS ref_questions;
-- DROP TABLE IF EXISTS student_profiles;
-- DROP TABLE IF EXISTS users;

-- ============================================
-- TABLE: users (Authentication)
-- ============================================
CREATE TABLE IF NOT EXISTS users (
    id_user INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(64) NOT NULL,
    nama_lengkap VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_username (username),
    INDEX idx_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- TABLE: student_profiles (Kategori A - Personal Data)
-- ============================================
CREATE TABLE IF NOT EXISTS student_profiles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_user INT NOT NULL,
    jenis_kelamin ENUM('L', 'P') DEFAULT 'L',
    status_pendidikan VARCHAR(50) DEFAULT 'Aktif',
    program_studi VARCHAR(100),
    semester ENUM('1', '2', '3', '4', '5', '6', '6+') DEFAULT '1',
    status_mahasiswa VARCHAR(50),
    latar_belakang VARCHAR(100),
    alasan_memilih_prodi VARCHAR(100),
    tujuan_kuliah VARCHAR(100),
    metode_belajar VARCHAR(100),
    motivasi_belajar TINYINT DEFAULT 3,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE,
    UNIQUE KEY unique_user_profile (id_user)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- TABLE: profil_lulusan (Career Profiles)
-- ============================================
CREATE TABLE IF NOT EXISTS profil_lulusan (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nama_profil VARCHAR(100) NOT NULL,
    deskripsi TEXT,
    skills_required TEXT,
    prospek_karir TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert sample career profiles
INSERT INTO profil_lulusan (nama_profil, deskripsi, skills_required, prospek_karir) VALUES
('Programmer', 'Ahli dalam pengembangan software dan aplikasi', 'Java, Python, C++, Database, Algorithm', 'Software Developer, Backend Engineer, Full-stack Developer'),
('Data Analyst', 'Menganalisis data untuk menghasilkan insight bisnis', 'Python, SQL, Excel, Statistics, Visualization', 'Business Analyst, Data Scientist, BI Analyst'),
('Network Engineer', 'Merancang dan mengelola infrastruktur jaringan', 'Cisco, Linux, Security, TCP/IP, Routing', 'Network Admin, System Engineer, Security Specialist'),
('UI/UX Designer', 'Merancang antarmuka dan pengalaman pengguna', 'Figma, Adobe XD, User Research, Prototyping', 'Product Designer, UX Researcher, Interface Designer'),
('Database Administrator', 'Mengelola dan mengoptimalkan database sistem', 'MySQL, PostgreSQL, Oracle, Performance Tuning', 'DBA, Database Engineer, Cloud Database Specialist'),
('DevOps Engineer', 'Mengintegrasikan development dan operations', 'Docker, Kubernetes, CI/CD, AWS, Linux', 'DevOps Specialist, Cloud Engineer, SRE'),
('Cyber Security Specialist', 'Melindungi sistem dari ancaman keamanan', 'Penetration Testing, Firewall, Encryption, SIEM', 'Security Analyst, Ethical Hacker, SOC Analyst')
ON DUPLICATE KEY UPDATE nama_profil=VALUES(nama_profil);

-- ============================================
-- TABLE: ref_questions (Master Questions)
-- ============================================
CREATE TABLE IF NOT EXISTS ref_questions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(20) UNIQUE NOT NULL,
    kategori ENUM('A', 'B', 'C') NOT NULL,
    question_text TEXT NOT NULL,
    question_type ENUM('single_choice', 'multiple_choice', 'scale', 'text') DEFAULT 'single_choice',
    question_order INT DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_kategori (kategori),
    INDEX idx_code (question_code)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert sample questions for testing
INSERT INTO ref_questions (question_code, kategori, question_text, question_type, question_order) VALUES
-- Kategori A (Personal) - 10 questions
('F_A1', 'A', 'Jenis Kelamin', 'single_choice', 1),
('F_A2', 'A', 'Status Pendidikan', 'single_choice', 2),
('F_A3', 'A', 'Program Studi', 'single_choice', 3),
('F_A4', 'A', 'Semester', 'single_choice', 4),
('F_A5', 'A', 'Status Mahasiswa', 'single_choice', 5),
('F_A6', 'A', 'Latar Belakang Pendidikan', 'single_choice', 6),
('F_A7', 'A', 'Alasan Memilih Prodi', 'single_choice', 7),
('F_A8', 'A', 'Tujuan Kuliah', 'single_choice', 8),
('F_A9', 'A', 'Metode Belajar Favorit', 'single_choice', 9),
('F_A10', 'A', 'Motivasi Belajar', 'scale', 10),

-- Kategori B (Academic) - 10 questions
('F_B1', 'B', 'IPK/GPA Anda', 'single_choice', 11),
('F_B2', 'B', 'Mata Kuliah Favorit', 'single_choice', 12),
('F_B3', 'B', 'Kemampuan Pemrograman', 'scale', 13),
('F_B4', 'B', 'Kemampuan Database', 'scale', 14),
('F_B5', 'B', 'Kemampuan Jaringan', 'scale', 15),
('F_B6', 'B', 'Kemampuan Design', 'scale', 16),
('F_B7', 'B', 'Pengalaman Proyek', 'single_choice', 17),
('F_B8', 'B', 'Sertifikasi yang Dimiliki', 'multiple_choice', 18),
('F_B9', 'B', 'Prestasi Akademik', 'single_choice', 19),
('F_B10', 'B', 'Keaktifan Organisasi', 'single_choice', 20),

-- Kategori C (Character) - 20 questions for MBTI-style
('F_C1', 'C', 'Saya suka bekerja dalam tim', 'scale', 21),
('F_C2', 'C', 'Saya lebih suka bekerja sendiri', 'scale', 22),
('F_C3', 'C', 'Saya senang memecahkan masalah kompleks', 'scale', 23),
('F_C4', 'C', 'Saya mudah beradaptasi dengan teknologi baru', 'scale', 24),
('F_C5', 'C', 'Saya detail dan teliti dalam pekerjaan', 'scale', 25),
('F_C6', 'C', 'Saya suka menganalisis data', 'scale', 26),
('F_C7', 'C', 'Saya tertarik dengan keamanan sistem', 'scale', 27),
('F_C8', 'C', 'Saya senang membuat tampilan yang menarik', 'scale', 28),
('F_C9', 'C', 'Saya suka belajar hal baru', 'scale', 29),
('F_C10', 'C', 'Saya dapat bekerja di bawah tekanan', 'scale', 30),
('F_C11', 'C', 'Saya senang mengajar orang lain', 'scale', 31),
('F_C12', 'C', 'Saya tertarik dengan infrastruktur IT', 'scale', 32),
('F_C13', 'C', 'Saya suka mengoptimasi performa sistem', 'scale', 33),
('F_C14', 'C', 'Saya senang melakukan riset', 'scale', 34),
('F_C15', 'C', 'Saya suka membuat dokumentasi', 'scale', 35),
('F_C16', 'C', 'Saya tertarik dengan cloud computing', 'scale', 36),
('F_C17', 'C', 'Saya senang berinteraksi dengan user', 'scale', 37),
('F_C18', 'C', 'Saya suka automasi dan scripting', 'scale', 38),
('F_C19', 'C', 'Saya tertarik dengan AI/Machine Learning', 'scale', 39),
('F_C20', 'C', 'Saya senang memimpin proyek', 'scale', 40)
ON DUPLICATE KEY UPDATE question_text=VALUES(question_text);

-- ============================================
-- TABLE: ref_question_options (Question Options)
-- ============================================
CREATE TABLE IF NOT EXISTS ref_question_options (
    id INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(20) NOT NULL,
    option_text VARCHAR(255) NOT NULL,
    option_value DECIMAL(5,2) NOT NULL,
    option_order INT DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code) ON DELETE CASCADE,
    INDEX idx_question (question_code)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert sample options (simplified for UI testing)
INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
-- F_A1 - Jenis Kelamin
('F_A1', 'Laki-laki', 1.0, 1),
('F_A1', 'Perempuan', 1.0, 2),

-- F_A2 - Status Pendidikan
('F_A2', 'Mahasiswa Aktif', 1.0, 1),
('F_A2', 'Non-Aktif', 0.5, 2),
('F_A2', 'Cuti', 0.5, 3),

-- F_A3 - Program Studi
('F_A3', 'Teknik Informatika', 1.0, 1),
('F_A3', 'Sistem Informasi', 1.0, 2),
('F_A3', 'Teknik Komputer', 1.0, 3),

-- F_A4 - Semester
('F_A4', 'Semester 1-2', 0.5, 1),
('F_A4', 'Semester 3-4', 0.7, 2),
('F_A4', 'Semester 5-6', 0.9, 3),
('F_A4', 'Semester 7+', 1.0, 4),

-- F_B1 - IPK
('F_B1', 'IPK 3.5 - 4.0', 1.0, 1),
('F_B1', 'IPK 3.0 - 3.49', 0.8, 2),
('F_B1', 'IPK 2.75 - 2.99', 0.6, 3),
('F_B1', 'IPK < 2.75', 0.4, 4)
ON DUPLICATE KEY UPDATE option_text=VALUES(option_text);

-- ============================================
-- TABLE: assessments (Test Sessions)
-- ============================================
CREATE TABLE IF NOT EXISTS assessments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    date_taken DATETIME DEFAULT CURRENT_TIMESTAMP,
    status ENUM('in_progress', 'completed', 'cancelled') DEFAULT 'in_progress',
    completed_at DATETIME NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id_user) ON DELETE CASCADE,
    INDEX idx_user (user_id),
    INDEX idx_status (status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- TABLE: responses (User Answers)
-- ============================================
CREATE TABLE IF NOT EXISTS responses (
    id INT AUTO_INCREMENT PRIMARY KEY,
    assessment_id INT NOT NULL,
    question_code VARCHAR(20) NOT NULL,
    value_input DECIMAL(5,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (assessment_id) REFERENCES assessments(id) ON DELETE CASCADE,
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code) ON DELETE CASCADE,
    INDEX idx_assessment (assessment_id),
    INDEX idx_question (question_code)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- TABLE: rules (Inference Rules - Simplified)
-- ============================================
CREATE TABLE IF NOT EXISTS rules (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rule_code VARCHAR(20) UNIQUE NOT NULL,
    profil_lulusan_id INT NOT NULL,
    cf_rule DECIMAL(3,2) DEFAULT 0.8,
    description TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (profil_lulusan_id) REFERENCES profil_lulusan(id) ON DELETE CASCADE,
    INDEX idx_profil (profil_lulusan_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert sample rules
INSERT INTO rules (rule_code, profil_lulusan_id, cf_rule, description) VALUES
('R1', 1, 0.85, 'High programming skill + good GPA -> Programmer'),
('R2', 2, 0.80, 'Good analytical skill + database knowledge -> Data Analyst'),
('R3', 3, 0.82, 'Network knowledge + infrastructure interest -> Network Engineer'),
('R4', 4, 0.78, 'Design interest + user-centric -> UI/UX Designer'),
('R5', 5, 0.83, 'Database skill + optimization interest -> DBA'),
('R6', 6, 0.81, 'Automation + cloud interest -> DevOps'),
('R7', 7, 0.84, 'Security interest + analytical -> Cyber Security')
ON DUPLICATE KEY UPDATE description=VALUES(description);

-- ============================================
-- TABLE: rule_conditions (Rule Conditions)
-- ============================================
CREATE TABLE IF NOT EXISTS rule_conditions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rule_id INT NOT NULL,
    question_code VARCHAR(20) NOT NULL,
    operator ENUM('>=', '>', '<=', '<', '=', '!=') DEFAULT '>=',
    threshold_value DECIMAL(5,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (rule_id) REFERENCES rules(id) ON DELETE CASCADE,
    FOREIGN KEY (question_code) REFERENCES ref_questions(question_code) ON DELETE CASCADE,
    INDEX idx_rule (rule_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Insert sample conditions (simplified)
INSERT INTO rule_conditions (rule_id, question_code, operator, threshold_value) VALUES
-- R1: Programmer
(1, 'F_B3', '>=', 0.8),
(1, 'F_B1', '>=', 0.7),
-- R2: Data Analyst
(2, 'F_C6', '>=', 0.8),
(2, 'F_B4', '>=', 0.7),
-- R3: Network Engineer
(3, 'F_B5', '>=', 0.8),
(3, 'F_C12', '>=', 0.7),
-- R4: UI/UX Designer
(4, 'F_B6', '>=', 0.8),
(4, 'F_C8', '>=', 0.7),
-- R5: DBA
(5, 'F_B4', '>=', 0.9),
(5, 'F_C13', '>=', 0.7),
-- R6: DevOps
(6, 'F_C18', '>=', 0.8),
(6, 'F_C16', '>=', 0.7),
-- R7: Cyber Security
(7, 'F_C7', '>=', 0.9),
(7, 'F_C5', '>=', 0.7)
ON DUPLICATE KEY UPDATE threshold_value=VALUES(threshold_value);

-- ============================================
-- TABLE: results (Assessment Results)
-- ============================================
CREATE TABLE IF NOT EXISTS results (
    id INT AUTO_INCREMENT PRIMARY KEY,
    assessment_id INT NOT NULL,
    profil_lulusan_id INT NOT NULL,
    cf_percentage DECIMAL(5,2) NOT NULL,
    ranking INT NOT NULL,
    matched_rules TEXT,
    explanation TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (assessment_id) REFERENCES assessments(id) ON DELETE CASCADE,
    FOREIGN KEY (profil_lulusan_id) REFERENCES profil_lulusan(id) ON DELETE CASCADE,
    INDEX idx_assessment (assessment_id),
    INDEX idx_ranking (ranking)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- INSERT SAMPLE USER FOR TESTING
-- ============================================
-- Password: test123 (hashed)
INSERT INTO users (username, password_hash, nama_lengkap, email) VALUES
('testuser', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', 'Test User', 'test@occupath.com')
ON DUPLICATE KEY UPDATE username=VALUES(username);

-- ============================================
-- VERIFICATION QUERIES
-- ============================================
SELECT 'Database setup completed!' as status;
SELECT COUNT(*) as total_users FROM users;
SELECT COUNT(*) as total_profiles FROM profil_lulusan;
SELECT COUNT(*) as total_questions FROM ref_questions;
SELECT COUNT(*) as total_rules FROM rules;

SHOW TABLES;
