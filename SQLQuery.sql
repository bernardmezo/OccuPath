-- Buat database baru
CREATE DATABASE OccupathDB;
GO

USE OccupathDB;
GO

-- Table Users
CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    nama_lengkap VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Table Student Profiles
CREATE TABLE student_profiles (
    id_profile INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    jenis_kelamin CHAR(1) NOT NULL, -- 'L' / 'P'
    status_pendidikan VARCHAR(20),
    program_studi VARCHAR(50),
    semester VARCHAR(5),
    status_mahasiswa VARCHAR(20),
    latar_belakang VARCHAR(50),
    alasan_memilih_prodi VARCHAR(50),
    tujuan_kuliah VARCHAR(50),
    metode_belajar VARCHAR(50),
    motivasi_belajar VARCHAR(5), 
    CONSTRAINT FK_Student_User FOREIGN KEY (id_user) REFERENCES users(id_user)
);
GO

-- Table Academic Data
CREATE TABLE academic_data (
    id_academic INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    ipk DECIMAL(3,2), -- misal 3.75
    tren_ipk VARCHAR(10), 
    mata_kuliah_disukai VARCHAR(100),
    mata_kuliah_tdk_disukai VARCHAR(100),
    kemampuan_analisis VARCHAR(5), 
    kemampuan_coding VARCHAR(5),   
    kemampuan_riset VARCHAR(5),   
    pengalaman_proyek VARCHAR(10), 
    akses_fasilitas VARCHAR(5),   
    penguasaan_software VARCHAR(10), 
    CONSTRAINT FK_Academic_User FOREIGN KEY (id_user) REFERENCES users(id_user)
);
GO

CREATE TABLE character_data (
    id_character INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    kategori VARCHAR(50),                  -- misal: "Kerja Tim & Kemandirian"
    kode_fakta VARCHAR(10) NOT NULL,       -- F_C56, F_C72, dst
    pernyataan VARCHAR(255) NOT NULL,      -- teks pertanyaan
    skala INT CHECK (skala BETWEEN 1 AND 5), -- jawaban 1–5
    CONSTRAINT FK_Character_User FOREIGN KEY (id_user) REFERENCES users(id_user)
);
GO

-- Table Rules
CREATE TABLE rules (
    id_rule INT IDENTITY(1,1) PRIMARY KEY,
    premis VARCHAR(MAX), -- bisa simpen JSON atau string IF..AND..
    kesimpulan VARCHAR(50),
    cf_rule DECIMAL(3,2) -- 0.00 - 1.00
);
GO

-- Table Recommendations
CREATE TABLE recommendations (
    id_rekomendasi INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    profil_rekomendasi VARCHAR(50),
    cf_total DECIMAL(3,2),
    tanggal DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Recommendation_User FOREIGN KEY (id_user) REFERENCES users(id_user)
);
GO
