-- ============================================
-- SQL Script: Data Pertanyaan Kategori A (Data Diri)
-- OccuPath - Sistem Pakar Profil Lulusan
-- ============================================
-- Jalankan script ini setelah Full_Database_Schema.sql

-- ============================================
-- CREATE REFERENCE TABLES (Jika belum ada)
-- ============================================

CREATE TABLE IF NOT EXISTS ref_questions (
    id_question INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(10) NOT NULL UNIQUE,
    kategori ENUM('A', 'B', 'C') NOT NULL,
    question_text TEXT NOT NULL,
    question_order INT NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS ref_question_options (
    id_option INT AUTO_INCREMENT PRIMARY KEY,
    question_code VARCHAR(10) NOT NULL,
    option_text VARCHAR(255) NOT NULL,
    option_value INT NOT NULL,
    option_order INT NOT NULL,
    CONSTRAINT FK_Option_Question FOREIGN KEY (question_code) REFERENCES ref_questions(question_code) ON DELETE CASCADE,
    UNIQUE KEY uk_question_option (question_code, option_text),
    INDEX idx_question_code (question_code)
);

-- ============================================
-- CLEAR EXISTING DATA untuk menghindari duplikasi
-- ============================================
DELETE FROM ref_question_options WHERE question_code LIKE 'F_A%';
DELETE FROM ref_questions WHERE kategori = 'A';

-- ============================================
-- INSERT PERTANYAAN KATEGORI A
-- ============================================

-- F_A1: Jenis Kelamin
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A1', 'A', 'Apa jenis kelamin Anda?', 1);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A1', 'Laki-laki', 1, 1),
('F_A1', 'Perempuan', 2, 2);

-- F_A2: Status Pendidikan
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A2', 'A', 'Apa status pendidikan Anda saat ini?', 2);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A2', 'Mahasiswa Aktif', 1, 1),
('F_A2', 'Mahasiswa Non-Aktif / Drop Out', 2, 2),
('F_A2', 'Mahasiswa Cuti', 3, 3);

-- F_A3: Program Studi
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A3', 'A', 'Apa program studi yang sedang Anda tempuh?', 3);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A3', 'Teknik Informatika', 1, 1),
('F_A3', 'Teknik Multimedia Digital', 2, 2),
('F_A3', 'Teknik Multimedia Jaringan', 3, 3);

-- F_A4: Semester
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A4', 'A', 'Anda saat ini berada di semester berapa?', 4);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A4', 'Semester 1', 1, 1),
('F_A4', 'Semester 2', 2, 2),
('F_A4', 'Semester 3', 3, 3),
('F_A4', 'Semester 4', 4, 4),
('F_A4', 'Semester 5', 5, 5),
('F_A4', 'Semester 6', 6, 6),
('F_A4', 'Semester 6+ (Lebih dari 6)', 7, 7);

-- F_A5: Status Mahasiswa
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A5', 'A', 'Apa status mahasiswa Anda?', 5);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A5', 'Reguler', 1, 1),
('F_A5', 'Paralel', 2, 2),
('F_A5', 'Eksekutif', 3, 3);

-- F_A6: Latar Belakang Pendidikan
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A6', 'A', 'Apa latar belakang pendidikan Anda sebelum kuliah?', 6);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A6', 'SMA IPA', 1, 1),
('F_A6', 'SMA IPS', 2, 2),
('F_A6', 'SMK Teknik', 3, 3),
('F_A6', 'SMK Non-Teknik', 4, 4),
('F_A6', 'Lainnya', 5, 5);

-- F_A7: Alasan Memilih Program Studi
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A7', 'A', 'Apa alasan utama Anda memilih program studi ini?', 7);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A7', 'Minat & Bakat Pribadi', 1, 1),
('F_A7', 'Prospek Kerja yang Baik', 2, 2),
('F_A7', 'Saran Orang Tua / Keluarga', 3, 3),
('F_A7', 'Ikut-ikutan Teman', 4, 4),
('F_A7', 'Pilihan Cadangan', 5, 5);

-- F_A8: Tujuan Kuliah
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A8', 'A', 'Apa tujuan utama Anda kuliah?', 8);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A8', 'Meningkatkan Karir', 1, 1),
('F_A8', 'Mendapatkan Gelar', 2, 2),
('F_A8', 'Menambah Ilmu & Skill', 3, 3),
('F_A8', 'Memperluas Relasi', 4, 4),
('F_A8', 'Mengisi Waktu', 5, 5);

-- F_A9: Metode Belajar Favorit
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A9', 'A', 'Metode belajar apa yang paling Anda sukai?', 9);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A9', 'Diskusi', 1, 1),
('F_A9', 'Membaca', 2, 2),
('F_A9', 'Praktik langsung', 3, 3),
('F_A9', 'Online learning', 4, 4);

-- F_A10: Tingkat Motivasi Belajar
INSERT INTO ref_questions (question_code, kategori, question_text, question_order) VALUES
('F_A10', 'A', 'Seberapa tinggi motivasi belajar Anda saat ini?', 10);

INSERT INTO ref_question_options (question_code, option_text, option_value, option_order) VALUES
('F_A10', '1 - Sangat Rendah', 1, 1),
('F_A10', '2 - Rendah', 2, 2),
('F_A10', '3 - Cukup', 3, 3),
('F_A10', '4 - Tinggi', 4, 4),
('F_A10', '5 - Sangat Tinggi', 5, 5);

-- ============================================
-- VERIFIKASI DATA
-- ============================================
-- SELECT q.question_code, q.question_text, o.option_text, o.option_value
-- FROM ref_questions q
-- JOIN ref_question_options o ON q.question_code = o.question_code
-- WHERE q.kategori = 'A'
-- ORDER BY q.question_order, o.option_order;
