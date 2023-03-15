using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RegistrationManagmentSimplified.Models;

namespace RegistrationManagmentSimplified.DB;

public partial class ProjectDBContext : DbContext
{
    public ProjectDBContext()
    {
    }

    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Concelho> Concelhos { get; set; }

    public virtual DbSet<Coordenador> Coordenadores { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EstadoCivil> EstadosCivis { get; set; }

    public virtual DbSet<EstadoInscricao> EstadosInscricao { get; set; }

    public virtual DbSet<FormacaoRequisito> FormacaoRequisitos { get; set; }

    public virtual DbSet<Formacao> Formacoes { get; set; }

    public virtual DbSet<Formando> Formandos { get; set; }

    public virtual DbSet<Habilitacao> Habilitacoes { get; set; }

    public virtual DbSet<IncricaoRequisito> IncricaoRequisitos { get; set; }

    public virtual DbSet<Inscricao> Inscricoes { get; set; }

    public virtual DbSet<NrTrabalhadoresOpcao> NrTrabalhadoresOpcoes { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<RegimesHorario> RegimesHorarios { get; set; }

    public virtual DbSet<RegimesPresenca> RegimesPresencas { get; set; }

    public virtual DbSet<Requisito> Requisitos { get; set; }

    public virtual DbSet<SitProfSubsidio> SitProfSubsidios { get; set; }

    public virtual DbSet<Subsidio> Subsidios { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }


    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Concelho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("concelhos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.DistritoId, "concelhos_distrito_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DistritoId).HasColumnName("distrito_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Distrito).WithMany(p => p.Concelhos)
                .HasForeignKey(d => d.DistritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("concelhos_distrito_id_foreign");
        });

        modelBuilder.Entity<Coordenador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("coordenadores")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarPath)
                .HasMaxLength(255)
                .HasDefaultValueSql("'Resources/images/default_avatar.png'")
                .HasColumnName("avatar_path");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("distritos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("empresas")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.NrTrabalhadoresId, "empresas_nr_trabalhadores_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MoradaEmpresa)
                .HasMaxLength(255)
                .HasColumnName("moradaEmpresa");
            entity.Property(e => e.NifEmpresa)
                .HasMaxLength(15)
                .HasColumnName("nifEmpresa");
            entity.Property(e => e.NomeEmpresa)
                .HasMaxLength(255)
                .HasColumnName("nomeEmpresa");
            entity.Property(e => e.NrTrabalhadoresId).HasColumnName("nr_trabalhadores_id");
            entity.Property(e => e.PostalEmpresa)
                .HasMaxLength(10)
                .HasColumnName("postalEmpresa");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.NrTrabalhadores).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.NrTrabalhadoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empresas_nr_trabalhadores_id_foreign");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("estados_civis")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EstadoInscricao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("estados_inscricao")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NomeEstado)
                .HasMaxLength(255)
                .HasColumnName("nome_estado");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FormacaoRequisito>(entity =>
        {
            entity.HasKey(e => new { e.RequisitoId, e.FormacaoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("formacao_requisito")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.FormacaoId, "formacao_requisito_formacao_id_foreign");

            entity.Property(e => e.RequisitoId).HasColumnName("requisito_id");
            entity.Property(e => e.FormacaoId).HasColumnName("formacao_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Formacao).WithMany(p => p.FormacaoRequisitos)
                .HasForeignKey(d => d.FormacaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formacao_requisito_formacao_id_foreign");

            entity.HasOne(d => d.Requisito).WithMany(p => p.FormacaoRequisitos)
                .HasForeignKey(d => d.RequisitoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formacao_requisito_requisito_id_foreign");
        });

        modelBuilder.Entity<Formacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("formacoes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CoordenadorId, "formacoes_coordenador_id_foreign");

            entity.HasIndex(e => e.RegimeHorarioId, "formacoes_regime_horario_id_foreign");

            entity.HasIndex(e => e.RegimePresencaId, "formacoes_regime_presenca_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoordenadorId).HasColumnName("coordenador_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DataInicioPrevista).HasColumnName("data_inicio_prevista");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .HasColumnName("descricao");
            entity.Property(e => e.DuracaoHoras).HasColumnName("duracao_horas");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.RegimeHorarioId).HasColumnName("regime_horario_id");
            entity.Property(e => e.RegimePresencaId).HasColumnName("regime_presenca_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Coordenador).WithMany(p => p.Formacos)
                .HasForeignKey(d => d.CoordenadorId)
                .HasConstraintName("formacoes_coordenador_id_foreign");

            entity.HasOne(d => d.RegimeHorario).WithMany(p => p.Formacos)
                .HasForeignKey(d => d.RegimeHorarioId)
                .HasConstraintName("formacoes_regime_horario_id_foreign");

            entity.HasOne(d => d.RegimePresenca).WithMany(p => p.Formacos)
                .HasForeignKey(d => d.RegimePresencaId)
                .HasConstraintName("formacoes_regime_presenca_id_foreign");
        });

        modelBuilder.Entity<Formando>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("formandos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ConcelhoId, "formandos_concelho_id_foreign");

            entity.HasIndex(e => e.EmpresaId, "formandos_empresa_id_foreign");

            entity.HasIndex(e => e.EstadoCivilId, "formandos_estado_civil_id_foreign");

            entity.HasIndex(e => e.HabilitacoesId, "formandos_habilitacoes_id_foreign");

            entity.HasIndex(e => e.NacionalidadeId, "formandos_nacionalidade_id_foreign");

            entity.HasIndex(e => e.NaturalidadeId, "formandos_naturalidade_id_foreign");

            entity.HasIndex(e => e.SubsidioId, "formandos_subsidio_id_foreign");

            entity.HasIndex(e => e.TipoDocumentoId, "formandos_tipo_documento_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnoConclusao).HasColumnName("ano_conclusao");
            entity.Property(e => e.AreaCurso)
                .HasMaxLength(255)
                .HasColumnName("area_curso");
            entity.Property(e => e.Certificado)
                .HasMaxLength(255)
                .HasColumnName("certificado");
            entity.Property(e => e.CodPostal)
                .HasMaxLength(10)
                .HasColumnName("cod_postal");
            entity.Property(e => e.ConcelhoId).HasColumnName("concelho_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Emprego)
                .HasMaxLength(255)
                .HasColumnName("emprego");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.EstabelecimentoEnino)
                .HasMaxLength(255)
                .HasColumnName("estabelecimento_enino");
            entity.Property(e => e.EstadoCivilId).HasColumnName("estado_civil_id");
            entity.Property(e => e.FimProff).HasColumnName("fim_proff");
            entity.Property(e => e.HabilitacoesId).HasColumnName("habilitacoes_id");
            entity.Property(e => e.InicioProff).HasColumnName("inicio_proff");
            entity.Property(e => e.Morada)
                .HasMaxLength(255)
                .HasColumnName("morada");
            entity.Property(e => e.NacionalidadeId).HasColumnName("nacionalidade_id");
            entity.Property(e => e.NaturalidadeId).HasColumnName("naturalidade_id");
            entity.Property(e => e.Nif)
                .HasMaxLength(15)
                .HasColumnName("nif");
            entity.Property(e => e.Niss)
                .HasMaxLength(15)
                .HasColumnName("niss");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.NrDocumento)
                .HasMaxLength(50)
                .HasColumnName("nr_documento");
            entity.Property(e => e.SubsidioId).HasColumnName("subsidio_id");
            entity.Property(e => e.Telemovel)
                .HasMaxLength(20)
                .HasColumnName("telemovel");
            entity.Property(e => e.TipoDocumentoId).HasColumnName("tipo_documento_id");
            entity.Property(e => e.UltimaProff)
                .HasMaxLength(255)
                .HasColumnName("ultima_proff");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValidadeDocumento).HasColumnName("validade_documento");

            entity.HasOne(d => d.Concelho).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.ConcelhoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formandos_concelho_id_foreign");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("formandos_empresa_id_foreign");

            entity.HasOne(d => d.EstadoCivil).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.EstadoCivilId)
                .HasConstraintName("formandos_estado_civil_id_foreign");

            entity.HasOne(d => d.Habilitacoes).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.HabilitacoesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formandos_habilitacoes_id_foreign");

            entity.HasOne(d => d.Nacionalidade).WithMany(p => p.FormandoNacionalidades)
                .HasForeignKey(d => d.NacionalidadeId)
                .HasConstraintName("formandos_nacionalidade_id_foreign");

            entity.HasOne(d => d.Naturalidade).WithMany(p => p.FormandoNaturalidades)
                .HasForeignKey(d => d.NaturalidadeId)
                .HasConstraintName("formandos_naturalidade_id_foreign");

            entity.HasOne(d => d.Subsidio).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.SubsidioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formandos_subsidio_id_foreign");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Formandos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formandos_tipo_documento_id_foreign");
        });

        modelBuilder.Entity<Habilitacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("habilitacoes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NomeDescritivo)
                .HasMaxLength(255)
                .HasColumnName("nome_descritivo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<IncricaoRequisito>(entity =>
        {
            entity.HasKey(e => new { e.RequisitoId, e.InscricaoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("incricao_requisito")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.InscricaoId, "incricao_requisito_inscricao_id_foreign");

            entity.Property(e => e.RequisitoId).HasColumnName("requisito_id");
            entity.Property(e => e.InscricaoId).HasColumnName("inscricao_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Inscricao).WithMany(p => p.IncricaoRequisitos)
                .HasForeignKey(d => d.InscricaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incricao_requisito_inscricao_id_foreign");

            entity.HasOne(d => d.Requisito).WithMany(p => p.IncricaoRequisitos)
                .HasForeignKey(d => d.RequisitoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incricao_requisito_requisito_id_foreign");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inscricoes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.FormacaoId, "inscricoes_formacao_id_foreign");

            entity.HasIndex(e => e.FormandoId, "inscricoes_formando_id_foreign");

            entity.HasIndex(e => e.IdEstado, "inscricoes_id_estado_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DataInscricao).HasColumnName("data_inscricao");
            entity.Property(e => e.FormacaoId).HasColumnName("formacao_id");
            entity.Property(e => e.FormandoId).HasColumnName("formando_id");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Preferencia).HasColumnName("preferencia");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Formacao).WithMany(p => p.Inscricos)
                .HasForeignKey(d => d.FormacaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscricoes_formacao_id_foreign");

            entity.HasOne(d => d.Formando).WithMany(p => p.Inscricos)
                .HasForeignKey(d => d.FormandoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscricoes_formando_id_foreign");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Inscricos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscricoes_id_estado_foreign");
        });

        modelBuilder.Entity<NrTrabalhadoresOpcao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("nr_trabalhadores__opcoes")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NomeOpcao)
                .HasMaxLength(255)
                .HasColumnName("nome_opcao");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paises")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RegimesHorario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("regimes_horario")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NomeRegime)
                .HasMaxLength(255)
                .HasColumnName("nome_regime");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RegimesPresenca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("regimes_presenca")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NomeRegime)
                .HasMaxLength(255)
                .HasColumnName("nome_regime");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Requisito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("requisitos")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SitProfSubsidio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sit_prof_subsidios")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Detalhes)
                .HasMaxLength(500)
                .HasColumnName("detalhes");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Subsidio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("subsidios")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tipos_documento")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
