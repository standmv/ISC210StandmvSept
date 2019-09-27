package com.demoyageek.tennisrpg_webapi.Repositories;

import com.demoyageek.tennisrpg_webapi.Entities.Score;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;
import org.springframework.stereotype.Repository;

@Repository
@RepositoryRestResource(path = "/score", collectionResourceRel = "scores")
public interface ScoreRepository extends JpaRepository<Score, Integer> {
    
}
